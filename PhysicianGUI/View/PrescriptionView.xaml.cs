﻿using Model.MedicalExam;
using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using HealthClinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for PrescriptionView.xaml
    /// </summary>
    public partial class PrescriptionView : UserControl
    {
        public PrescriptionView()
        {
            InitializeComponent();
        }

        private void medicineDosageDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            medicineDosageScrollViewer.ScrollToVerticalOffset(medicineDosageScrollViewer.VerticalOffset - e.Delta);
        }

        private void AddDosageButton_Click(object sender, RoutedEventArgs e)
        {
            AddMedicineDosageDialog addMedicineDosageDialog = new AddMedicineDosageDialog();
            addMedicineDosageDialog.DataContext = new AddMedicineDosageViewModel();
            addMedicineDosageDialog.Owner = Application.Current.MainWindow;
            addMedicineDosageDialog.ShowDialog();
        }

        private void EditDosageButton_Click(object sender, RoutedEventArgs e)
        {
            MedicineDosage medicineDosage = (MedicineDosage)medicineDosageDataGrid.SelectedItem;
            AddMedicineDosageDialog addMedicineDosageDialog = new AddMedicineDosageDialog();
            addMedicineDosageDialog.DataContext = new AddMedicineDosageViewModel(medicineDosage);
            addMedicineDosageDialog.Owner = Application.Current.MainWindow;
            addMedicineDosageDialog.ShowDialog();
        }

        private void DeleteDosageButton_Click(object sender, RoutedEventArgs e)
        {
            MedicineDosage medicineDosage = (MedicineDosage)medicineDosageDataGrid.SelectedItem;
            Messenger.Default.Send<DeleteMedicineDosageMessage>(new DeleteMedicineDosageMessage { medicineDosage = medicineDosage });
        }

        private void medicineDosageDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isRowSelected;
            if (medicineDosageDataGrid.SelectedItem == null)
            {
                isRowSelected = false;
            }
            else
            {
                isRowSelected = true;
            }
            Messenger.Default.Send<DataGridSelectionChangedMessage>(new DataGridSelectionChangedMessage { dataGridRowIsSelected = isRowSelected });
        }
    }
}
