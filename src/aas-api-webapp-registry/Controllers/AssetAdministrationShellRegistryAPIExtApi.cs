/*
 * DotAAS Part 2 | HTTP/REST | Entire API Collection
 *
 * The entire API collection as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: V1.0RC03
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 * 
 * Attention: The API methods of this controller are not part of the official AAS Standard, but are listed in the 
 *            Asset Administration Shell Registry API of the Entire API Collection swagger file
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using AAS.API.Attributes;

using Microsoft.AspNetCore.Authorization;
using AAS.API.Models;
using Microsoft.Extensions.Logging;
using AAS.API.Registry;
using System.Web;
using System.Net.WebSockets;
using AAS.API.Interfaces;

namespace AAS.API.WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiController]
    public class AssetAdministrationShellRegistryAPIExtApiController : ControllerBase
    {
        private readonly ILogger _logger;

        private AASRegistry registryService;

        public AssetAdministrationShellRegistryAPIExtApiController(ILogger<AssetAdministrationShellRegistryAPIExtApiController> log, AASRegistry registry)
        {
            _logger = log;
            registryService = registry;
        }

        private IActionResult AASRegistryException(AASRegistryException aasEx)
        {
            return StatusCode(500, new AAS.API.Models.Result()
            {
                Success = false,
                Messages = new List<Message>() {
                        new Message() { MessageType = Message.MessageTypeEnum.ExceptionEnum,
                        Code = "500", Text = aasEx.Message, Timestamp = DateTime.UtcNow.ToString("o")} }
            });
        }

        /// <summary>
        /// Deletes a Submodel Descriptor, i.e. de-registers a submodel
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor deleted successfully</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpDelete]
        [Route("api/v1/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteSubmodelDescriptorByIdAASRegistry")]
        [SwaggerResponse(statusCode: 404, type: typeof(Result), description: "Not Found")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult DeleteSubmodelDescriptorByIdAASRegistry([FromRoute][Required]string aasIdentifier, [FromRoute][Required]string submodelIdentifier)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all Submodel Descriptors
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptors</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpGet]
        [Route("api/v1/shell-descriptors/{aasIdentifier}/submodel-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("GetAllSubmodelDescriptorsAASRegistry")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SubmodelDescriptor>), description: "Requested Submodel Descriptors")]
        [SwaggerResponse(statusCode: 404, type: typeof(Result), description: "Not Found")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult GetAllSubmodelDescriptorsAASRegistry([FromRoute][Required]string aasIdentifier)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<SubmodelDescriptor>));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "[ \"{ \"identification\": \"https://admin-shell.io/zvei/nameplate/1/0/Nameplate\", \"endpoints\": [ { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:1234\", \"endpointProtocolVersion\": \"1.1\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"opc.tcp://localhost:4840\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:5678\", \"endpointProtocolVersion\": \"1.1\", \"subprotocol\": \"OPC UA Basic SOAP\", \"subprotocolBody\": \"ns=2;s=MyAAS\", \"subprotocolBodyEncoding\": \"application/soap+xml\" }, \"interface\": \"AAS-1.0\" } ] }\", \"{ \"identification\": \"https://admin-shell.io/zvei/nameplate/1/0/Nameplate\", \"endpoints\": [ { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:1234\", \"endpointProtocolVersion\": \"1.1\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"opc.tcp://localhost:4840\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:5678\",\"endpointProtocolVersion\": \"1.1\", \"subprotocol\": \"OPC UA Basic SOAP\", \"subprotocolBody\": \"ns=2;s=MyAAS\", \"subprotocolBodyEncoding\": \"application/soap+xml\" }, \"interface\": \"AAS-1.0\" } ] }\" ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<SubmodelDescriptor>>(exampleJson)
                        : default(List<SubmodelDescriptor>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns a specific Submodel Descriptor
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptor</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpGet]
        [Route("api/v1/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetSubmodelDescriptorByIdAASRegistry")]
        [SwaggerResponse(statusCode: 200, type: typeof(SubmodelDescriptor), description: "Requested Submodel Descriptor")]
        [SwaggerResponse(statusCode: 404, type: typeof(Result), description: "Not Found")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult GetSubmodelDescriptorByIdAASRegistry([FromRoute][Required]string aasIdentifier, [FromRoute][Required]string submodelIdentifier)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(SubmodelDescriptor));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "\"{ \"identification\": \"https://admin-shell.io/zvei/nameplate/1/0/Nameplate\", \"endpoints\": [ { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:1234\", \"endpointProtocolVersion\": \"1.1\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"opc.tcp://localhost:4840\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:5678\", \"endpointProtocolVersion\": \"1.1\", \"subprotocol\": \"OPC UA Basic SOAP\", \"subprotocolBody\": \"ns=2;s=MyAAS\", \"subprotocolBodyEncoding\": \"application/soap+xml\" }, \"interface\": \"AAS-1.0\" } ] }\"";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<SubmodelDescriptor>(exampleJson)
                        : default(SubmodelDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates a new Submodel Descriptor, i.e. registers a submodel
        /// </summary>
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="201">Submodel Descriptor created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpPost]
        [Route("api/v1/shell-descriptors/{aasIdentifier}/submodel-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("PostSubmodelDescriptorAASRegistry")]
        [SwaggerResponse(statusCode: 201, type: typeof(SubmodelDescriptor), description: "Submodel Descriptor created successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(Result), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(Result), description: "Not Found")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult PostSubmodelDescriptorAASRegistry([FromBody]SubmodelDescriptor body, [FromRoute][Required]byte[] aasIdentifier)
        { 
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(SubmodelDescriptor));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Result));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = "\"{ \"identification\": \"https://admin-shell.io/zvei/nameplate/1/0/Nameplate\", \"endpoints\": [ { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:1234\", \"endpointProtocolVersion\": \"1.1\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"opc.tcp://localhost:4840\" }, \"interface\": \"AAS-1.0\" }, { \"protocolInformation\": { \"endpointAddress\": \"https://localhost:5678\", \"endpointProtocolVersion\": \"1.1\", \"subprotocol\": \"OPC UA Basic SOAP\", \"subprotocolBody\": \"ns=2;s=MyAAS\", \"subprotocolBodyEncoding\": \"application/soap+xml\" }, \"interface\": \"AAS-1.0\" } ] }\"";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<SubmodelDescriptor>(exampleJson)
                        : default(SubmodelDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Updates an existing Submodel Descriptor
        /// </summary>
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (UTF8-BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpPut]
        [Route("api/v1/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PutSubmodelDescriptorByIdAASRegistry")]
        [SwaggerResponse(statusCode: 400, type: typeof(Result), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(Result), description: "Not Found")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult PutSubmodelDescriptorByIdAASRegistry([FromBody]SubmodelDescriptor body, [FromRoute][Required]string aasIdentifier, [FromRoute][Required]string submodelIdentifier)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Result));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Result));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));

            throw new NotImplementedException();
        }
    }
}
