﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/14/2013
 * Time: 1:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    using System.Windows.Automation;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of InputValidationAspect.
    /// </summary>
    public class InputValidationAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            // foreach (var argument in invocation.GenericArguments) {
            foreach (var argument in invocation.Arguments) {
//                if (null == argument) {
//                    if (argument is AutomationElement) {
//                        // throw 
//                    }
//                    if (argument is IUiElement) {
//                        // throw
//                    }
//                }
                
                bool wrongInput = false;
                if (wrongInput) {
                    // log
                    
                    // return with output
                }
            }
            
            invocation.Proceed();
        }
    }
}