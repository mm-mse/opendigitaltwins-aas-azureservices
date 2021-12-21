/*
 * DotAAS Part 2 | HTTP/REST | Entire Interface Collection
 *
 * The entire interface collection as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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
using AAS.API.AASXFile;
using AAS.API.Models.Interfaces;

namespace AAS.API.WebApp.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AASXFileServerInterfaceApiController : ControllerBase
    {
        private readonly ILogger _logger;

        private AASAASXFile fileService;

        public AASXFileServerInterfaceApiController(ILogger<AASXFileServerInterfaceApiController> logger, AASAASXFile service) : base()
        {
            _logger = logger;
            fileService = service;
        }

        /// <summary>
        /// Deletes a specific AASX package from the server
        /// </summary>
        /// <param name="packageId">The Package Id (BASE64-URL-encoded)</param>
        /// <response code="204">Deleted successfully</response>
        [HttpDelete]
        [Route("/packages/{packageId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAASXByPackageId")]
        public virtual IActionResult DeleteAASXByPackageId([FromRoute][Required]string packageId)
        {
            _logger.LogInformation($"DeleteAASXByPackageId called for Package with id '{packageId}'");

            if (fileService == null)
            {
                _logger.LogError("Invalid setup. No Blob file service configured. Check DI setup");
                throw new AASXFileServiceException("Invalid setup. No Blob file service configured. Check DI setup");
            }

            fileService.DeleteAASXByPackageId(packageId).GetAwaiter().GetResult();

            return StatusCode(204);
        }

        /// <summary>
        /// Returns a specific AASX package from the server
        /// </summary>
        /// <param name="packageId">The package Id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested AASX package</response>
        [HttpGet]
        [Route("/packages/{packageId}")]
        [ValidateModelState]
        [SwaggerOperation("GetAASXByPackageId")]
        [SwaggerResponse(statusCode: 200, type: typeof(byte[]), description: "Requested AASX package")]
        public virtual IActionResult GetAASXByPackageId([FromRoute][Required]string packageId)
        { 

            _logger.LogInformation($"GetAASXByPackageId called for Package with id '{packageId}'");

            if (fileService == null)
            {
                _logger.LogError("Invalid setup. No Blob file service configured. Check DI setup");
                throw new AASXFileServiceException("Invalid setup. No Blob file service configured. Check DI setup");
            }

            PackageFile packageFile = fileService.GetAASXByPackageId(packageId).GetAwaiter().GetResult();

            if (packageFile != null)
            {
                HttpContext.Response.Headers.Add("X-FileName", packageFile.Filename);
                return new ObjectResult(packageFile.Contents);
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Returns a list of available AASX packages at the server
        /// </summary>
        /// <param name="aasId">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested package list</response>
        [HttpGet]
        [Route("/packages")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAASXPackageIds")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageDescription>), description: "Requested package list")]
        public virtual IActionResult GetAllAASXPackageIds([FromQuery]string aasId)
        { 
            _logger.LogInformation($"GetAllAASXPackageIds called for AAS id '{aasId}'");

            if (fileService == null)
            {
                _logger.LogError("Invalid setup. No Blob file service configured. Check DI setup");
                throw new AASXFileServiceException("Invalid setup. No Blob file service configured. Check DI setup");
            }

            List<PackageDescription> result = fileService.GetAllAASXPackageIds(aasId).GetAwaiter().GetResult();
            return StatusCode(200, result);
        }

        /// <summary>
        /// Stores the AASX package at the server
        /// </summary>
        /// <param name="aasxPackage"></param>
        /// <response code="201">AASX package stored successfully</response>
        [HttpPost]
        [Route("/packages")]
        [ValidateModelState]
        [SwaggerOperation("PostAASXPackage")]
        [SwaggerResponse(statusCode: 201, type: typeof(PackageDescription), description: "AASX package stored successfully")]
        public virtual IActionResult PostAASXPackage([FromBody] PackagesBody aasxPackage)
        {
            _logger.LogInformation($"PostAASXPackage called for Package '{aasxPackage}'");

            if (fileService == null)
            {
                _logger.LogError("Invalid setup. No Blob file service configured. Check DI setup");
                throw new AASXFileServiceException("Invalid setup. No Blob file service configured. Check DI setup");
            }

            PackageDescription result = fileService.StoreAASXPackage(aasxPackage.AasIds, aasxPackage.File, aasxPackage.FileName).GetAwaiter().GetResult();

            return StatusCode(201, result);
        }

        /// <summary>
        /// Updates the AASX package at the server
        /// </summary>
        /// <param name="packageId">The Package Id (BASE64-URL-encoded)</param>
        /// <response code="204">AASX package updated successfully</response>
        [HttpPut]
        [Route("/packages/{packageId}")]
        [ValidateModelState]
        [SwaggerOperation("PutAASXByPackageId")]
        [SwaggerResponse(statusCode: 204, type: typeof(PackageDescription), description: "AASX package updated successfully")]
        public virtual IActionResult PutAASXByPackageId([FromRoute][Required] string packageId, [FromBody] PackagesBody aasxPackage)
        {
            _logger.LogInformation($"PutAASXByPackageId called for Package '{aasxPackage}'");

            if (fileService == null)
            {
                _logger.LogError("Invalid setup. No Blob file service configured. Check DI setup");
                throw new AASXFileServiceException("Invalid setup. No Blob file service configured. Check DI setup");
            }

            PackageDescription result = fileService.UpdateAASXPackage(packageId, aasxPackage.AasIds, aasxPackage.File, aasxPackage.FileName).GetAwaiter().GetResult();

            return StatusCode(204, result);
        }
    }
}
