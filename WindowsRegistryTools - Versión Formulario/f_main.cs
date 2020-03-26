﻿using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WindowsRegistryTools {
    public partial class f_main: Form {

        RegistryTools_ registro = new RegistryTools_();

        public f_main() {
            InitializeComponent();
        }
        private void btnCrearKey(object sender, EventArgs e) {
          //  Ruta completa del registro
          //Ejemplo: @"HKEY_CURRENT_USER\Contenedor1"
            string ruta = crearKey_Path.Text.ToString();
           // valueName del nuevo contenedor
            string nombre = crearKey_key.Text.ToString();
           // El mensaje de confirmación o de Falló se mostrará en la pantalla
            txt_info.Text = registro.CreateKey(ruta, nombre);





        }
        private void btnCrearValues(object sender, EventArgs e) {
            // Ruta completa del registro
            //Ejemplo: @"HKEY_CURRENT_USER\Contenedor1"
            string ruta = crearLlave_ruta.Text.ToString();

            // valueName del la llave
            string valueName = crearLlave_name.Text.ToString();
            //Valor tipos texto
            string valueData = createLlave_value.Text.ToString();
            // String
            if (rb_String.Checked) {
                // El mensaje de confirmación o de Falló se mostrará en la pantalla
                txt_info.Text = registro.CreateKeyValue_String(ruta, valueName, valueData);
            }
            //Binarie
            if (rb_binarie.Checked) {
                    bool hola;
                    //Palabras claves para saltar 
                    Char [] caractersalto = { ' ', ',' };
                    // Nuevo array con saltos de linea
                    String [] valueDataSaltos = valueData.Split(caractersalto);
                    // Nuevo array de valores tipo binario
                    byte [] valueDataB = new byte [valueDataSaltos.Length];
                try {
                    // Verificar parse dato por dato 
                    for (int i = 0; i < valueDataSaltos.Length; i++) {
                        // Inserta datos en binario
                        valueDataB [i] = byte.Parse(valueDataSaltos [i]);
                    }
                    hola = true;
                } catch {
                    hola = false;
                    txt_info.Text = "Ingrese los datos correctamente";
                }
                if (hola) {
                    // Proceso de Insertar Datos a los registros (Regedit
                   txt_info.Text = registro.CreateKeyValue_Binary(ruta, valueName, valueDataB);
                } else {
                    txt_info.Text = "Ingrese los datos correctamente";
                }
            }
            //DWORD
            if (rb_DWORD.Checked) {
                                // El mensaje de confirmación o de Falló se mostrará en la pantalla
                Int32 valori = Int32.Parse(createLlave_value.Text);
                txt_info.Text = registro.CreateKeyValue_DWORD(ruta, valueName, valori);
            }
            //QWORD
            if (rb_QWORD.Checked) {
                                // El mensaje de confirmación o de Falló se mostrará en la pantalla
                Int64 valori = Int64.Parse(createLlave_value.Text);
                txt_info.Text = registro.CreateKeyValue_QWORD(ruta, valueName, valori);
            }
            //MultiString
            if (rb_multiString.Checked) {
                // El mensaje de confirmación o de Falló se mostrará en la pantalla
                string [] stringML = { createLlave_value.Text.ToString() };
                txt_info.Text = registro.CreateKeyValue_MultiString(ruta, valueName, stringML);
            }
            //Expandable String
            if (rb_expString.Checked) {
                // El mensaje de confirmación o de Falló se mostrará en la pantalla
                txt_info.Text = registro.CreateKeyValue_ExpandString(ruta, valueName, valueData);
            }
        }
        private void btnGetDataValue(object sender, EventArgs e) {
                                                                                                                                                                           
        }
        private void btnDeleteValues(object sender, EventArgs e) {

            string ruta = deleteLlave_ruta.Text.ToString();
            string nombre = deleteLlave_name.Text.ToString();
            txt_info.Text = registro.DeleteValue(ruta, nombre);

        }
        private void btnDeleteKey(object sender, EventArgs e) {
            string ruta = deleteAll_ruta.Text.ToString();
            txt_info.Text = registro.DeleteKey(ruta);
        }
   

        private void BtnExit(object sender, EventArgs e) {
            this.Close();
        }

        private void rb_multiString_CheckedChanged(object sender, EventArgs e) {
            if (rb_multiString.Checked) {
                createLlave_value.Multiline = true;
            } else {
                createLlave_value.Multiline = false;


            }
        }
    }  


}
