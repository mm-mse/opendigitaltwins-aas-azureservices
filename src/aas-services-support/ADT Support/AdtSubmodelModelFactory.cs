﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AasCore.Aas3_0_RC02;
using AdtModels.AdtModels;
using Azure.DigitalTwins.Core;

namespace AAS_Services_Support.ADT_Support
{
    public class AdtSubmodelModelFactory : AdtGeneralModelFactory
    {
        private readonly IAdtSubmodelInteractions _adtSubmodelInteractions;
        private readonly IAdtInteractions _adtInteractions;
        private AdtSubmodelAndSmcInformation<AdtSubmodel> submodelInformation;

        public AdtSubmodelModelFactory(IAdtSubmodelInteractions adtSubmodelInteractions, IAdtInteractions adtInteractions)
        {
            _adtSubmodelInteractions = adtSubmodelInteractions;
            _adtInteractions = adtInteractions;
        }


        public async Task<Submodel> GetSubmodelFromTwinId(string submodelTwinId)
        {
            this.submodelInformation = await _adtSubmodelInteractions.GetAllInformationForSubmodelWithTwinId(submodelTwinId);
            var submodel = CreateSubmodelFromAdtSubmodel();
            //submodel.EmbeddedDataSpecifications = GetEmbeddedDataSpecifications(submodelInformation);
            submodel.SemanticId =
                GetSemanticId(this.submodelInformation.ConcreteAasInformation.semanticId);
            foreach (var dataSpecification in submodelInformation.ConcreteAasInformation.dataSpecifications)
            {
                submodel.EmbeddedDataSpecifications.Add(
                    CreateEmbeddedDataSpecificationFromAdtDataSpecification(dataSpecification));
            }

            foreach (var supplementalSemanticId in submodelInformation.ConcreteAasInformation.supplementalSemanticId)
            {
                submodel.SupplementalSemanticIds.Add(GetSemanticId(supplementalSemanticId));
            }

            submodel.SubmodelElements = GetSubmodelElementsFromAdtSubmodelAndSMCInformation();

            return submodel;
        }

        private Submodel CreateSubmodelFromAdtSubmodel()
        {
            var adtSubmodel = this.submodelInformation.RootElement;
            Submodel submodel = new Submodel(adtSubmodel.Id);
            submodel.Category = adtSubmodel.Category;
            submodel.Checksum = adtSubmodel.Checksum;
            submodel.IdShort = adtSubmodel.IdShort;
            submodel.Kind = adtSubmodel.Kind.Kind == "Instance" ? ModelingKind.Instance : ModelingKind.Template;
            submodel.Description = ConvertAdtLangStringToGeneraLangString(adtSubmodel.Description);
            submodel.DisplayName = ConvertAdtLangStringToGeneraLangString(adtSubmodel.DisplayName);
            submodel.EmbeddedDataSpecifications = new List<EmbeddedDataSpecification>();
            submodel.SubmodelElements = new List<ISubmodelElement>();
            submodel.SupplementalSemanticIds = new List<Reference>();
            return submodel;
        }


        private List<ISubmodelElement> GetSubmodelElementsFromAdtSubmodelAndSMCInformation()
        {
            var submodelElements = new List<ISubmodelElement>();
            foreach (var adtProperty in submodelInformation.properties)
            {
                var property = new Property(DataTypeDefXsd.String);
                property = UpdateSubmodelElementFromAdtSubmodelElement(property, adtProperty);
                //property.EmbeddedDataSpecifications = GetEmbeddedDataSpecifications(adtProperty.dtId);
                property.Value = adtProperty.Value;
                property.SemanticId = GetSemanticIdForTwin(adtProperty.dtId);
                property.SupplementalSemanticIds = GetSupplementalSemanticIdsForTwin(adtProperty.dtId);

                submodelElements.Add(property);
            }

            foreach (var adtFile in submodelInformation.files)
            {
                var file = new File(adtFile.ContentType);
                file = UpdateSubmodelElementFromAdtSubmodelElement(file, adtFile);
                file.Value = adtFile.Value;
                file.SemanticId = GetSemanticIdForTwin(adtFile.dtId);
                file.SupplementalSemanticIds = GetSupplementalSemanticIdsForTwin(adtFile.dtId);
                submodelElements.Add(file);
            }

            foreach (var smeCollectionInformation in submodelInformation.smeCollections)
            {
                var smeC = CreateSubmodelElementCollectionFromSmeCollectionInformation(smeCollectionInformation);
                submodelElements.Add(smeC);
            }


            return submodelElements;
        }

        private Reference GetSemanticIdForTwin(string twinId)
        {
            try
            {
                var adtSemanticId = GetAdtSemanticId(twinId);
                return GetSemanticId(adtSemanticId);

            }
            catch (NoSemanticIdFound e)
            {
                Console.WriteLine(e);
            }
            return null;
        }


        private AdtReference GetAdtSemanticId(string twinId)
        {
            if (submodelInformation.definitionsAndSemantic.Relationships.ContainsKey(twinId))
            {
                foreach (var relationship in submodelInformation.definitionsAndSemantic.Relationships[twinId])
                {
                    if (relationship.Name == "semanticId")
                    {
                        return submodelInformation.definitionsAndSemantic.References[relationship.TargetId];
                    }
                }
            }

            throw new NoSemanticIdFound($"No Semantic Id found for twin with dtId {twinId}");
        }

        private List<Reference> GetSupplementalSemanticIdsForTwin(string twinId)
        {
            var supplementalSemanticIds = new List<Reference>();

            var adtSupplementalsSemanticIds = GetAdtSupplementalsSemanticIdsForTwin(twinId);
            if (adtSupplementalsSemanticIds.Count == 0)
            {
                return null;
            }
            foreach (var adtSupplementalsSemanticId in adtSupplementalsSemanticIds)
            {
                supplementalSemanticIds.Add(GetSemanticId(adtSupplementalsSemanticId));

            }
            return supplementalSemanticIds;
        }

        private List<AdtReference> GetAdtSupplementalsSemanticIdsForTwin(string twinId)
        {
            var adtSupplementalSemanticIds = new List<AdtReference>();
            if (submodelInformation.definitionsAndSemantic.Relationships.ContainsKey(twinId))
            {
                foreach (var relationship in submodelInformation.definitionsAndSemantic.Relationships[twinId])
                {
                    if (relationship.Name == "supplementalSemanticId")
                    {
                        adtSupplementalSemanticIds.Add(submodelInformation.definitionsAndSemantic.References[relationship.TargetId]);
                    }
                }
            }

            return adtSupplementalSemanticIds;

        }

        private T UpdateSubmodelElementFromAdtSubmodelElement<T>(T sme, AdtSubmodelElement adtSubmodelElement) where T : ISubmodelElement
        {

            sme.Kind = adtSubmodelElement.Kind.Kind == "Instance"
                ? ModelingKind.Instance
                : ModelingKind.Template;
            sme.DisplayName = ConvertAdtLangStringToGeneraLangString(adtSubmodelElement.DisplayName);
            sme.Description = ConvertAdtLangStringToGeneraLangString(adtSubmodelElement.Description);
            sme.Category = adtSubmodelElement.Category;
            sme.Checksum = adtSubmodelElement.Checksum;
            sme.IdShort = adtSubmodelElement.IdShort;

            return sme;
        }

        private List<EmbeddedDataSpecification> GetEmbeddedDataSpecifications<T>(AdtSubmodelAndSmcInformation<T> information) where T : AdtBase, new()
        {
            var embeddedDataSpecifications = new List<EmbeddedDataSpecification>();
            List<BasicRelationship> twinRelationships;
            try
            {
                twinRelationships = information.definitionsAndSemantic.Relationships[information.RootElement.dtId];


                foreach (var twinRelationship in twinRelationships)
                {
                    if (twinRelationship.Name == "semanticId")
                    {
                        var semanticIdReference =
                            information.definitionsAndSemantic.References[twinRelationship.TargetId];
                        var conceptDescription = GetConceptDescription(semanticIdReference.dtId);

                        if (conceptDescription != null)
                        {
                            var adtDataSpecificationIec61360 =
                                GetDataSpecificationIec61360ForTwinWithId(conceptDescription.dtId);
                            var dataSpecificationIec61360 =
                                GetIec61360DataSpecificationContent(adtDataSpecificationIec61360);

                            var keys = new List<Key>()
                            { new Key(KeyTypes.GlobalReference, conceptDescription.Id) };
                            var dataSpecification = new Reference(ReferenceTypes.GlobalReference, keys);
                            embeddedDataSpecifications.Add(new EmbeddedDataSpecification(dataSpecification,
                                dataSpecificationIec61360));
                        }

                    }

                    else if (twinRelationship.Name == "dataSpecification")
                    {
                        var adtDataSpecificationIec61360 = information.definitionsAndSemantic.Iec61360s[twinRelationship.TargetId];
                        var dataSpecificationIec61360 = GetIec61360DataSpecificationContent(adtDataSpecificationIec61360);
                        var keys = new List<Key>()
                        { new Key(KeyTypes.GlobalReference, adtDataSpecificationIec61360.UnitIdValue) };
                        var dataSpecification = new Reference(ReferenceTypes.GlobalReference, keys);
                        embeddedDataSpecifications.Add(new EmbeddedDataSpecification(dataSpecification,
                            dataSpecificationIec61360));
                    }
                }
            }
            catch (Exception e)
            {


            }

            foreach (var smeCollection in information.smeCollections)
            {
                embeddedDataSpecifications.AddRange(GetEmbeddedDataSpecifications(smeCollection));
            }
            return embeddedDataSpecifications;
        }

        private AdtConceptDescription GetConceptDescription(string dtId)
        {
            var twinRelationships = this.submodelInformation.definitionsAndSemantic.Relationships[dtId];
            foreach (var twinRelationship in twinRelationships)
            {
                if (twinRelationship.Name == "referredElement")
                {
                    try

                    {
                        var conceptDescription =
                            submodelInformation.definitionsAndSemantic.ConceptDescriptions[twinRelationship.TargetId];
                        return conceptDescription;
                    }
                    catch (Exception e)
                    {

                    }

                }
            }
            return null;
        }
        private AdtDataSpecificationIEC61360 GetDataSpecificationIec61360ForTwinWithId(string twinId)
        {
            var twinRelationships = this.submodelInformation.definitionsAndSemantic.Relationships[twinId];
            foreach (var twinRelationship in twinRelationships)
            {
                if (twinRelationship.Name == "referredElement")
                {
                    return GetDataSpecificationIec61360ForTwinWithId(twinRelationship.TargetId);
                }
                else if (twinRelationship.Name == "dataSpecification")
                {
                    return submodelInformation.definitionsAndSemantic.Iec61360s[twinRelationship.TargetId];
                }
            }
            throw new AdtException($"Could not find DataSpecificationIec61360 for twinId {twinId}");
        }

        private SubmodelElementCollection CreateSubmodelElementCollectionFromSmeCollectionInformation(
            AdtSubmodelElementCollectionInformation information)
        {
            var factory = new AdtSmeCollectionModelFactory(information);
            var smeCollection = factory.GetSmeCollection();
            return smeCollection;
        }
    }
}
