/*
   Copyright 2011-2013 repetier repetierdev@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using RepetierHost;
using RepetierHost.view.utils;

namespace RepetierHost.model
{
    public class PrinterModel : INotifyPropertyChanged
    {
        private RegistryKey key;
        private bool updating = false;
        public PrinterModel()
        {
            key = Main.printerSettings.currentPrinterKey;
            Main.printerSettings.eventPrinterChanged += PrinterChanged;
            // Default settinsg from previous installations without separate storage
            BasicConfiguration b = BasicConfiguration.basicConf;
            readPrinterSettings();
        }
 
  
        private void readPrinterSettings() {
        }
        public void PrinterChanged(RegistryKey printerKey,bool printerChanged) {
            key = printerKey;
            readPrinterSettings();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
