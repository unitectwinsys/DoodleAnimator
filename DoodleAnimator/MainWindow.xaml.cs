using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; //For : BitmapImage etc etc
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Layout.Core;
using DevExpress.Xpf.Docking;
using System.Windows.Markup; //xamlwriter
using System.IO; //stringreader
using System.Xml; //xmlreader
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Ink;                   //For : InkCanvas
using System.Windows.Input.StylusPlugIns;   //For : DrawingAttributes

namespace DoodleAnimator
{
    public partial class MainWindow : DXRibbonWindow
    {
        public ListBoxItem ItemManipulated = new ListBoxItem();
        public string inkCXaml = "";
        public string Accion = "";
        public int IndexAnt = 0;
        public MenuItem Item_Cut = new MenuItem();
        public MenuItem Item_Copy = new MenuItem();
        public MenuItem Item_Paste = new MenuItem();
        public MenuItem Item_Delete = new MenuItem();
        public MenuItem Item_Duplicate = new MenuItem();
        public MenuItem Item_Insert = new MenuItem();
        public bool ImportingFile = false;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void DXRibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Creando el Primer Frame y Guardando el Valor
            inkCXaml = XamlWriter.Save(inkCanvas1);

            ListBoxItem lbItem = new ListBoxItem();
            lbItem.Content = inkCXaml;
            lbItem.Width = 10;
            listboxTimeLine.Items.Add(lbItem);

            //Haciendo el Frame Activo
            listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(0);

            #region Menu de Opciones Frames
            ContextMenu cMenu = null;
            cMenu = new ContextMenu();

            Item_Insert = new MenuItem();
            Item_Insert.Header = "Insertar Fotograma";
            Item_Insert.Click += new RoutedEventHandler(Item_Insert_Click);

            Item_Delete = new MenuItem();
            Item_Delete.Header = "Eliminar Fotograma";
            Item_Delete.Click += new RoutedEventHandler(Item_Delete_Click);

            Item_Cut = new MenuItem();
            Item_Cut.Header = "Cortar Fotograma";
            Item_Cut.Click += new RoutedEventHandler(Item_Cut_Click);

            Item_Copy = new MenuItem();
            Item_Copy.Header = "Copiar Fotograma";
            Item_Copy.Click += new RoutedEventHandler(Item_Copy_Click);

            Item_Duplicate = new MenuItem();
            Item_Duplicate.Header = "Duplicar Fotograma";
            Item_Duplicate.Click += new RoutedEventHandler(Item_Duplicate_Click);

            Item_Paste = new MenuItem();
            Item_Paste.Header = "Pegar Fotograma";
            Item_Paste.Click += new RoutedEventHandler(Item_Paste_Click);

            cMenu.Items.Add(Item_Insert);
            cMenu.Items.Add(Item_Delete);
            cMenu.Items.Add(Item_Cut);
            cMenu.Items.Add(Item_Copy);
            cMenu.Items.Add(Item_Duplicate);
            cMenu.Items.Add(Item_Paste);

            listboxTimeLine.ContextMenu = cMenu;
            #endregion
        }

        private void listboxTimeLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lb = (ListBoxItem)listboxTimeLine.SelectedItem;

            //Pasandolo a Ink Canvas
            if (listboxTimeLine.Items.Contains(lb))
            {
                StringReader stringReader = new StringReader(lb.Content.ToString());
                XmlReader xmlReader = XmlReader.Create(stringReader);
                InkCanvas inkCanvas2 = new InkCanvas();
                inkCanvas2 = (InkCanvas)XamlReader.Load(xmlReader);

                inkCanvas1.Strokes = inkCanvas2.Strokes;
            }
        }

        private void btnAddFrame_Click(object sender, RoutedEventArgs e)
        {
            GuardarFrame();

            //Limpiando InkCanvas y Creando Item Nuevo
            inkCanvas1.Strokes.Clear();
            ListBoxItem lbItem = new ListBoxItem();
            lbItem.Content = XamlWriter.Save(inkCanvas1);
            lbItem.Width = 10;

            listboxTimeLine.Items.Add(lbItem);
            listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(listboxTimeLine.Items.Count - 1);
        }

        public void GuardarFrame()
        {
            //Actualizando Frame Actual antes de crear el nuevo
            ItemManipulated = (ListBoxItem)listboxTimeLine.SelectedItem;
            ItemManipulated.Content = XamlWriter.Save(inkCanvas1);
        }

        private void listboxTimeLine_LayoutUpdated(object sender, EventArgs e)
        {
            slider.Width = listboxTimeLine.Items.Count * 10;
            slider.Maximum = listboxTimeLine.Items.Count - 1;
        }
        private void listboxTimeLine_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Accion != "Eliminar")
                GuardarFrame();
        }

        private void slider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Accion != "Eliminar")
                GuardarFrame();
        }

        #region Frames - Acciones Basicas
        public void CortarFrame()
        {
            try
            {
                //Validando que si solo hay 1 fotograma no pueda cortarlo, dejaria la TimeLine Vacia
                if (listboxTimeLine.Items.Count == 1)
                {
                    MessageBox.Show("La Linea de Tiempo no puede quedar Vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Accion = "Cortar";
                GuardarFrame();
                ItemManipulated = (ListBoxItem)listboxTimeLine.SelectedItem;
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error Item Cut: " + exs.Message);
            }
        }
        public void CopiarFrame()
        {
            try
            {
                Accion = "Copiar";
                GuardarFrame();
                ItemManipulated = (ListBoxItem)listboxTimeLine.SelectedItem;
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error Item Copy: " + exs.Message);
            }
        }
        public void DuplicateFrame()
        {
            try
            {
                GuardarFrame();
                //Obteniendo Posicion Actual
                int indexActual = listboxTimeLine.SelectedIndex;

                //Agregando Item donde el Usuario dio Click > Pegar
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = ItemManipulated.Content;
                lbi.Width = 10;

                listboxTimeLine.Items.Insert(indexActual, lbi);
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error Item Copy: " + exs.Message);
            }
        }
        public void PasteFrame()
        {
            try
            {
                //Obteniendo Posicion Actual
                int indexActual = listboxTimeLine.SelectedIndex;

                //Agregando Item donde el Usuario dio Click > Pegar
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = ItemManipulated.Content;
                lbi.Width = 10;

                listboxTimeLine.Items.Insert(indexActual, lbi);
                if (Accion == "Cortar")
                    listboxTimeLine.Items.Remove(ItemManipulated);
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error Item Paste: " + exs.Message);
            }
        }
        public void InsertFrame()
        {
            try
            {
                Accion = "Insertar";
                int indiceActual = listboxTimeLine.SelectedIndex;
                GuardarFrame();

                //Limpiando InkCanvas y Creando Item Nuevo
                inkCanvas1.Strokes.Clear();
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = XamlWriter.Save(inkCanvas1);
                lbItem.Width = 10;

                listboxTimeLine.Items.Insert(indiceActual + 1, lbItem);
                listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(indiceActual + 1);
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error al Insertar Frame: " + exs.Message);
            }
        }
        public void DeleteFrame()
        {
            try
            {
                //Validando que si solo hay 1 fotograma no pueda cortarlo, dejaria la TimeLine Vacia
                if (listboxTimeLine.Items.Count == 1)
                {
                    MessageBox.Show("La Linea de Tiempo No puede quedar Vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Accion = "Eliminar";
                GuardarFrame();
                int indexItemDelete = listboxTimeLine.SelectedIndex;
                listboxTimeLine.Items.RemoveAt(indexItemDelete);

                //Seleccionar el Siguiente o el Anterior
                if (indexItemDelete == 0)
                    listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(0);
                else
                    listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(indexItemDelete - 1);
                Accion = "";
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error Item Delete: " + exs.Message);
            }
        }
        #endregion
        #region Frames - Menu
        private void Item_Cut_Click(object sender, EventArgs e)
        {
            CortarFrame();
        }
        private void Item_Copy_Click(object sender, EventArgs e)
        {
            CopiarFrame();
        }
        private void Item_Duplicate_Click(object sender, EventArgs e)
        {
            DuplicateFrame();
        }
        private void Item_Paste_Click(object sender, EventArgs e)
        {
            PasteFrame();
        }
        private void Item_Insert_Click(object sender, EventArgs e)
        {
            InsertFrame();
        }
        private void Item_Delete_Click(object sender, EventArgs e)
        {
            DeleteFrame();
        }
        #endregion
        #region Frames - Botones
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InsertFrame();
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            DeleteFrame();
        }
        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            CortarFrame();
        }
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            CopiarFrame();
        }
        private void btnDuplicate_Click(object sender, RoutedEventArgs e)
        {
            DuplicateFrame();
        }
        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            PasteFrame();
        }
        #endregion

        private void bNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainWindow frm = new MainWindow();
            frm.Show();
        }
        private void bPlay_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (listboxTimeLine.Items.Count == 1)
            {
                MessageBox.Show("Solo hay 1 fotograma");
                return;
            }
            GuardarFrame();
            double MiliSegundos = 1000 / Convert.ToDouble(txtFPS.EditValue);
            // slider.Value = 0;
            for (int i = 0; i < listboxTimeLine.Items.Count; i++)
            {
                slider.Value = i;
                //---
                slider.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate()
                {
                    slider.UpdateLayout();
                }));
                System.Threading.Thread.Sleep(Convert.ToInt32(MiliSegundos));
                //----
            }
        }

        private void bClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                GuardarFrame();
                //Crear cadena XAML que guarda el objeto ListBox
                string mystrXAML = XamlWriter.Save(listboxTimeLine);

                // Create SaveFileDialog
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

                // Set filter for file extension and default file extension
                dlg.DefaultExt = ".xml";
                dlg.Filter = "Text documents (.xml)|*.xml";

                // Display SaveFileDialog by calling ShowDialog method
                Nullable<bool> result = dlg.ShowDialog();

                // Get the selected file name and display in a TextBox
                string filename = "";
                if (result == true)
                {
                    // Open document
                    filename = dlg.FileName;
                    //Crear Stream del Archivo
                    FileStream fs = File.Create(filename);
                    //Se guarda cadena XAML, en el archivo creado a traves de un Stream Writer
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(mystrXAML);
                    sw.Close();
                    fs.Close();
                }           
            }
            catch (Exception exs)
            {
                MessageBox.Show("Error Save: " + exs.Message);
            }
        }

        private void bOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportingFile = false;
            Opening_Importing_File();
        }
        private void bImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            GuardarFrame();
            ImportingFile = true;
            Opening_Importing_File();
        }

        public void Opening_Importing_File()
        {
            // Create SaveFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Text documents (.xml)|*.xml";

            // Display SaveFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            string filename = "";
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
                ListBox lb2;
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    //lb2 - Listbox que se guardo en el archivo
                    lb2 = (ListBox)XamlReader.Load(fs);
                    int CurrentIndex = 0;
                    if (ImportingFile == false)
                        listboxTimeLine.Items.Clear();
                    else
                        CurrentIndex = listboxTimeLine.SelectedIndex;
                    for (int i = 0; i < lb2.Items.Count; i++)
                    {
                        //lbi2 - Item del Listbox lb2
                        ListBoxItem lbi2 = new ListBoxItem();
                        lbi2.Content = ((ListBoxItem)lb2.Items[i]).Content;
                        lbi2.Width = 10;
                        //listboxTimeLine.Items.Add(lbi2);
                        listboxTimeLine.Items.Insert(CurrentIndex, lbi2);
                        CurrentIndex++;
                    }

                    //Haciendo el Frame Activo
                    if (ImportingFile == false)
                        listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(0);
                }
            }
        }

        private void bPause_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            listboxTimeLine.SelectedItem = listboxTimeLine.Items.GetItemAt(0);
        }

        private void bClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            inkCanvas1.Strokes.Clear();
        }

        private void bEraserSmall_ItemClick(object sender, ItemClickEventArgs e)
        {
            inkCanvas1.EraserShape = new RectangleStylusShape(10, 10);
            var editMode = inkCanvas1.EditingMode;
            inkCanvas1.EditingMode = InkCanvasEditingMode.None;
            inkCanvas1.EditingMode = editMode;
        }

        private void bEraserLarge_ItemClick(object sender, ItemClickEventArgs e)
        {
            inkCanvas1.EraserShape = new RectangleStylusShape(50,50);
            var editMode = inkCanvas1.EditingMode;
            inkCanvas1.EditingMode = InkCanvasEditingMode.None;
            inkCanvas1.EditingMode = editMode;
        }

        private void bEraser_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByPoint;

            inkCanvas1.EraserShape = new RectangleStylusShape(30, 30);
            var editMode = inkCanvas1.EditingMode;
            inkCanvas1.EditingMode = InkCanvasEditingMode.None;
            inkCanvas1.EditingMode = editMode;

        }

        private void bSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.inkCanvas1.Select(this.inkCanvas1.Strokes);
        }

        private void bPencil_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void DXRibbonWindow_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Guarda el Frame, cuando el usuario da clic en cualquier parte de la linea de tiempo o la ventana
            GuardarFrame();
        }

    }
}
