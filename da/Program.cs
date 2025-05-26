/******************************************************************************
** Copyright (c) 2006-2023 Unified Automation GmbH All rights reserved.
**
** Software License Agreement ("SLA") Version 2.8
**
** Unless explicitly acquired and licensed from Licensor under another
** license, the contents of this file are subject to the Software License
** Agreement ("SLA") Version 2.8, or subsequent versions
** as allowed by the SLA, and You may not copy or use this file in either
** source code or executable form, except in compliance with the terms and
** conditions of the SLA.
**
** All software distributed under the SLA is provided strictly on an
** "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
** AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
** LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
** PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the SLA for specific
** language governing rights and limitations under the SLA.
**
** Project: .NET based OPC UA Client Server SDK
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.8/
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace da
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // applications without a UnifiedAutomation license embedded as a resource will stop working after 1 hour.
                ApplicationLicenseManager.AddProcessLicenses(System.Reflection.Assembly.GetExecutingAssembly(), "da.License.License.lic");

                // Create the certificate if it does not exist yet
                ApplicationInstance.Default.AutoCreateCertificate = true;

                // start the application.
                ApplicationInstance.Default.Start(Program.Run, ApplicationInstance.Default);
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(null, e);
                return;
            }
        }

        /// <summary>
        /// Implements the user defined logic after the UA application initializes.
        /// </summary>
        [STAThread]
        static void Run(object userState)
        {
            ApplicationInstance applicationInstance = userState as ApplicationInstance;
            System.Windows.Forms.Application.Run(new Form1(applicationInstance));
        }
    }
}
