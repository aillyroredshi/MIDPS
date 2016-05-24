using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineSweep;


using Xamarin.Forms;

namespace MineSweep
{
    public partial class SweepPage : ContentPage
    {
        public SweepPage()
        {

            InitializeComponent();

        }


        Button[,] Arr;
        Button button = new Button();
        Game mine;

     
        //private async void knopka(object sender, EventArgs e)
        //{

        //    await Navigation.PushAsync(new ContentPage
        //    {
        //        Content = new Button
        //        {
                    
        //            Text = "Play *.mp3 file!",
        //            Command = new Command(() =>
        //             {
        //                 Xamarin.Forms.DependencyService.Get<IAudio>().PlayMp3File("Alpha.mp3");



        //             })



        //        }
        //    });
        //}
    
        Button btn = new Button();
        private async void buttons(object sender, EventArgs e)
        {


            await Navigation.PushAsync(new ContentPage
            {

                Content = new Button
                {
                    Text = "OK",

                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.FromRgb(133, 33, 133),
                   
                },
   
               

            });

        }



        int width = 7;
        int height = 10;
   
        Grid mineGrid = new Grid();
        private async void ok(object sender, EventArgs e)
        {
          
            Arr = new Button[width, height];
            mine = new Game(width, height);

            for (int i = 0; i < width; i++)
            {

                mineGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < height; i++)
            {
                mineGrid.RowDefinitions.Add(new RowDefinition());
            }
            this.Content = mineGrid;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Button button = new Button();
                    
                    Arr[i, j] = button;
                    
                    button.Text = ".";
                    //button.Text = mine.array[i, j] == -1 ? "B" : mine.array[i, j] == 0 ? " " : mine.array[i, j].ToString();
                    mineGrid.Children.Add(button);
                    int t = i;
                    int t2 = j;

                    BackgroundColor = Color.Teal;

                    button.Clicked += (s, args) => Button_Clicked(t, t2);
                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                }
            }           
        }


 
   

        private   void Button_Clicked(int x, int y  )
        {
           
            var result = mine.Dig(x, y);
            if (result == null )
            {
                Arr[x, y].Text = "B";
                DisplayAlert("You Lose", ":(", "OK");
                
                Arr[x, y].IsVisible = false;
                if (Arr[x, y].Text == "B")
                {
                    Page page = new ContentPage();
                  //  return new NavigationPage(new Page());


                }

                return  ;
            }
            foreach (var item in result)
            {
                Arr[item.Key.Item1, item.Key.Item2].Text = item.Value == -1 ? "B" : item.Value == 0 ? " " : item.Value.ToString();
            
                
               
            }

            if ( mine.CheckState()==true )
            {
                DisplayAlert("Cool", "You win!", "OK");
            }
            

        }


        private void Btn_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}

