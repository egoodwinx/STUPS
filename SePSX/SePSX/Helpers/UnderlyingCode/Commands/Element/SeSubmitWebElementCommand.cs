﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SeSubmitWebElementCommand.
    /// </summary>
    internal class SeSubmitWebElementCommand : SeWebElementCommand
    {
        internal SeSubmitWebElementCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.SubmitWebElement(
                Cmdlet,
                ((IWebElement[])((SubmitSeWebElementCommand)Cmdlet).InputObject));
        }
    }
}
