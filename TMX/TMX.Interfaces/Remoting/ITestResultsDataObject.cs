﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2014
 * Time: 3:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of ITestResultsDataObject.
    /// </summary>
    public interface ITestResultsDataObject
    {
        string Data { get; set; }
        // XDocument Doc { get; set; }
        // List<ITestSuite> Data { get; set; }
    }
}