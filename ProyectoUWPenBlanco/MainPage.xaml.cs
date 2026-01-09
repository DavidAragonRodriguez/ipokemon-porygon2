using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ProyectoUWPenBlanco
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Establecer sliders a 100
            slVida.Value = 100;
            slEnergia.Value = 100;

            // Establecer valores iniciales en el control de usuario
            ucPorygon2DAR.Vida = 100;
            ucPorygon2DAR.Energia = 100;

            // Marcar todos los checkboxes de Interfaz Gráfica
            cbFondo.IsChecked = true;
            cbFilaVida.IsChecked = true;
            cbFilaEnergia.IsChecked = true;
            cbPocionVida.IsChecked = true;
            cbPocionEnergia.IsChecked = true;
            cbNombre.IsChecked = true;

            // Aplicar en el control de usuario
            ucPorygon2DAR.verFondo(true);
            ucPorygon2DAR.verFilaVida(true);
            ucPorygon2DAR.verFilaEnergia(true);
            ucPorygon2DAR.verPocionVida(true);
            ucPorygon2DAR.verPocionEnergia(true);
            ucPorygon2DAR.verNombre(true);

            // Activar también los estados animados por defecto si lo deseas
            cbAnimacionIddle.IsChecked = true;
            ucPorygon2DAR.activarAniIdle(true);
        }

        private void cambiarVida(object sender, RangeBaseValueChangedEventArgs e)
        {
            //Obtener valor actual del slider y poner ese valor en la propiedad Vida del Control de Usuario
            ucPorygon2DAR.Vida = e.NewValue;
        }

        private void cambiarEnergía(object sender, RangeBaseValueChangedEventArgs e)
        {
            //Obtener valor actual del slider y poner ese valor en la propiedad Energía del Control de Usuario
            ucPorygon2DAR.Energia = e.NewValue;
        }

        private async void EjecutarAtaqueFuerte(object sender, RoutedEventArgs e)
        {
            //Invocar la función animacionAtaqueFuerte implementada en el Control de Usuario
            bool estaCansado = cbAnimacionCansado.IsChecked == true;
            bool estaHerido = cbAnimacionHerido.IsChecked == true;
            bool estaIddle = cbAnimacionIddle.IsChecked == true;

            cbAnimacionEscudo.IsChecked = false;

            //DesmarcarEstados();
            //ucPorygon2DAR.animacionAtaqueFuerte();

            if (estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionCansadoYHeridoAHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionAtaqueFuerte();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionHerido();
                await Task.Delay(1100);
                ucPorygon2DAR.animacionHeridoACansadoYHerido();
            }
            else if(!estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionAtaqueFuerte();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionHerido();
            }
            else if(estaCansado && !estaHerido)
            {
                ucPorygon2DAR.animacionNoCansado();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionAtaqueFuerte();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionCansado();
            }
            else if (estaIddle)
            {
                ucPorygon2DAR.activarAniIdle(false);
                ucPorygon2DAR.animacionAtaqueFuerte();
                await Task.Delay(3000);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else
            {
                ucPorygon2DAR.animacionAtaqueFuerte();
            }
        }

        private async void EjecutarAtaqueFlojo(object sender, RoutedEventArgs e)
        {
            //Invocar la función animacionAtaqueFlojo implementada en el Control de Usuario
            bool estaCansado = cbAnimacionCansado.IsChecked == true;
            bool estaHerido = cbAnimacionHerido.IsChecked == true;
            bool estaIddle = cbAnimacionIddle.IsChecked == true;

            cbAnimacionEscudo.IsChecked = false;

            //DesmarcarEstados();
            //ucPorygon2DAR.animacionAtaqueFlojo();

            if (estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionCansadoYHeridoAHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionAtaqueFlojo();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionHerido();
                await Task.Delay(1100);
                ucPorygon2DAR.animacionHeridoACansadoYHerido();
            }
            else if (!estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionAtaqueFlojo();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionHerido();
            }
            else if (estaCansado && !estaHerido)
            {
                ucPorygon2DAR.animacionNoCansado();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionAtaqueFlojo();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionCansado();
            }
            else if (estaIddle)
            {
                ucPorygon2DAR.activarAniIdle(false);
                ucPorygon2DAR.animacionAtaqueFlojo();
                await Task.Delay(3000);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else
            {
                ucPorygon2DAR.animacionAtaqueFlojo();
            }
        }

        private async void EjecutarDefensa(object sender, RoutedEventArgs e)
        {
            //Invocar la función animacionDefensa implementada en el Control de Usuario
            bool estaCansado = cbAnimacionCansado.IsChecked == true;
            bool estaHerido = cbAnimacionHerido.IsChecked == true;
            bool estaIddle = cbAnimacionIddle.IsChecked == true;

            cbAnimacionEscudo.IsChecked = false;

            if (estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionCansadoYHeridoAHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDefensa();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionHerido();
                await Task.Delay(1100);
                ucPorygon2DAR.animacionHeridoACansadoYHerido();
            }
            else if (!estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDefensa();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionHerido();
            }
            else if (estaCansado && !estaHerido)
            {
                ucPorygon2DAR.animacionNoCansado();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDefensa();
                await Task.Delay(3000);
                ucPorygon2DAR.animacionCansado();
            }
            else if (estaIddle)
            {
                ucPorygon2DAR.activarAniIdle(false);
                ucPorygon2DAR.animacionDefensa();
                await Task.Delay(3000);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else
            {
                ucPorygon2DAR.animacionDefensa();
            }

            cbAnimacionEscudo.IsChecked = true;
        }

        private async void EjecutarDescansar(object sender, RoutedEventArgs e)
        {
            //Invocar la función animacionDescansar implementada en el Control de Usuario
            bool estaCansado = cbAnimacionCansado.IsChecked == true;
            bool estaHerido = cbAnimacionHerido.IsChecked == true;
            bool estaIddle = cbAnimacionIddle.IsChecked == true;

            cbAnimacionEscudo.IsChecked = false;

            if (estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionCansadoYHeridoAHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDescansar();
                await Task.Delay(3500);
                ucPorygon2DAR.animacionHerido();
                await Task.Delay(1100);
                ucPorygon2DAR.animacionHeridoACansadoYHerido();
            }
            else if (!estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionNoHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDescansar();
                await Task.Delay(3500);
                ucPorygon2DAR.animacionHerido();
            }
            else if (estaCansado && !estaHerido)
            {
                ucPorygon2DAR.animacionNoCansado();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDescansar();
                await Task.Delay(3500);
                ucPorygon2DAR.animacionCansado();
            }
            else if (estaIddle)
            {
                ucPorygon2DAR.activarAniIdle(false);
                ucPorygon2DAR.animacionDescansar();
                await Task.Delay(3500);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else
            {
                ucPorygon2DAR.animacionDescansar();
            }
        }

        private async void activarIddle(object sender, RoutedEventArgs e)
        {
            //Invocar activarAniIdle(true);
            if(cbAnimacionCansado.IsChecked == true && cbAnimacionHerido.IsChecked == true)
            {
                cbAnimacionCansado.IsChecked = false;
                await Task.Delay(1000);
                cbAnimacionHerido.IsChecked = false;
                await Task.Delay(1000);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else if(cbAnimacionCansado.IsChecked == true && cbAnimacionHerido.IsChecked == false)
            {
                cbAnimacionCansado.IsChecked = false;
                await Task.Delay(1000);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else if (cbAnimacionCansado.IsChecked == false && cbAnimacionHerido.IsChecked == true)
            {
                cbAnimacionHerido.IsChecked = false;
                await Task.Delay(1000);
                ucPorygon2DAR.activarAniIdle(true);
            }
            else
            {
                ucPorygon2DAR.activarAniIdle(true);
            }

        }

        private void desactivarIddle(object sender, RoutedEventArgs e)
        {
            //Invocar activarAniIdle(false);
            ucPorygon2DAR.activarAniIdle(false);
        }

        private void activarCansado(object sender, RoutedEventArgs e)
        {
            cbAnimacionIddle.IsChecked = false;

            if (cbAnimacionHerido.IsChecked == true)
                ucPorygon2DAR.animacionHeridoACansadoYHerido();
            else
                ucPorygon2DAR.animacionCansado();
        }

        private void desactivarCansado(object sender, RoutedEventArgs e)
        {
            if (cbAnimacionHerido.IsChecked == true)
                ucPorygon2DAR.animacionCansadoYHeridoAHerido();
            else
                ucPorygon2DAR.animacionNoCansado();
        }

        private void activarHerido(object sender, RoutedEventArgs e)
        {
            cbAnimacionIddle.IsChecked = false;

            if (cbAnimacionCansado.IsChecked == true)
                ucPorygon2DAR.animacionCansadoACansadoYHerido();
            else
                ucPorygon2DAR.animacionHerido();
        }

        private void desactivarHerido(object sender, RoutedEventArgs e)
        {
            if (cbAnimacionCansado.IsChecked == true)
                ucPorygon2DAR.animacionCansadoYHeridoACansado();
            else
                ucPorygon2DAR.animacionNoHerido();
        }

        private void activarEscudo(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verEscudo(true);
        }

        private void desactivarEscudo(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verEscudo(false);
        }

        private void verFondo(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verFondo(true);
        }

        private void noVerFondo(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verFondo(false);
        }

        private void verFilaVida(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verFilaVida(true);

        }

        private void noVerFilaVida(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verFilaVida(false);
        }

        private void verFilaEnergia(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verFilaEnergia(true);
        }

        private void noVerFilaEnergía(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verFilaEnergia(false);
        }

        private void verPocimaVida(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verPocionVida(true);
        }

        private void noVerPocimaVida(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verPocionVida(false);
        }

        private void verPocimaEnergia(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verPocionEnergia(true);
        }

        private void noVerPocimaEnergia(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verPocionEnergia(false);
        }

        private void verNombrePokemon(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verNombre(true);
        }

        private void noVerNombrePokemon(object sender, RoutedEventArgs e)
        {
            ucPorygon2DAR.verNombre(false);
        }

        private async void EjecutarDerrota(object sender, RoutedEventArgs e)
        {

            bool estaCansado = cbAnimacionCansado.IsChecked == true;
            bool estaHerido = cbAnimacionHerido.IsChecked == true;
            bool estaIddle = cbAnimacionIddle.IsChecked == true;

            cbAnimacionEscudo.IsChecked = false;

            if (estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionCansadoYHeridoAHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDerrota();
            }
            else if (!estaCansado && estaHerido)
            {
                ucPorygon2DAR.animacionDerrota();
            }
            else if (estaCansado && !estaHerido)
            {
                ucPorygon2DAR.animacionNoCansado();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionHerido();
                await Task.Delay(1000);
                ucPorygon2DAR.animacionDerrota();
            }
            else if (estaIddle)
            {
                ucPorygon2DAR.activarAniIdle(false);
                ucPorygon2DAR.animacionDerrota();
            }
            else
            {
                ucPorygon2DAR.animacionDerrota();
            }
        }

    }
}
