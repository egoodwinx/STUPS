﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/28/2014
 * Time: 4:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Xml.Linq;
    using Spring.Http;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.TestStructure;
//	using Spring.Http.Converters.Xml;
    using Spring.Rest.Client;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestResultsSender.
    /// </summary>
    public class TestResultsSender
    {
        // volatile RestTemplate _restTemplate;
        readonly IRestOperations _restTemplate; // chrome-extension://aejoelaoggembcahagimdiliamlcdmfm/dhc.html#void
        
        public TestResultsSender(RestRequestCreator requestCreator)
        {
        	_restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual bool SendTestResults()
        {
            var testResultsExporter = new TestResultsExporter();
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(
                        new SearchCmdletBaseDataObject {
                            FilterAll = true
                        },
                        TestData.TestSuites,
                        TestData.TestPlatforms);
            
            var dataObject = new TestResultsDataObject {
                Data = xDoc.ToString()
            };
            
            try {
            	var urn = UrlList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrlList.TestResultsPostingPoint_forClient_relPath;
            	var sendingResultsResponse = _restTemplate.PostForMessage(urn, dataObject);
            	return HttpStatusCode.Created == sendingResultsResponse.StatusCode;
            }
            catch (RestClientException eSendingTestResults) {
                // TODO: AOP
                Trace.TraceError("SendTestResults()");
                Trace.TraceError(eSendingTestResults.Message);
                throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
            }
	    }
    }
}
