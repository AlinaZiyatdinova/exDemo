using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDemoZiaytdinova.Models;
using WpfDemoZiaytdinova.Services;

namespace WpfDemoZiaytdinova
{
    public partial class MainWindow : Window
    {
        List<Partner> partners = new List<Partner>();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                partners = GetAllPartnerDB();
                if (partners != null)
                {
                    PartnersListBox.ItemsSource = partners;
                }
                else
                {
                    SetErrorMessage("Данные о парнерах отсутвуют");
                }
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message.ToString());
            }
        }

        public List<Partner>? GetAllPartnerDB()
        {
            try
            {
                using (var db = new AppDBContext())
                {
                    var partners = db.Partners.Include(a=>a.PartnerType).ToList();
                    if (partners != null)
                    {
                        foreach (var partner in partners)
                        {
                            if (partner != null)
                            {
                                partner.TotalSales = db.PartnerProducts.Where(p => p.PartnerId == partner.Id).Sum(p => Convert.ToDecimal(p.Count));
                                partner.Discount = PartnerService.GetDiscount((decimal)partner.TotalSales);
                            }
                        }
                        return partners;
                    }
                    else
                    {
                        SetErrorMessage("Данные о парнерах отсутвуют");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message.ToString());
                return null;
            }
        }

        public void SetErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void UpdatePartnerDB(Partner partner)
        {
            using(var db = new AppDBContext())
            {
                if(partner != null)
                {
                    var partnerExist = db.Partners.Where(p => p.Id == partner.Id).FirstOrDefault();
                    if(partnerExist != null)
                    {
                        partnerExist.Name = partner.Name;
                        partnerExist.Address = partner.Address;
                        partnerExist.Inn = partner.Inn;
                        partnerExist.Director = partner.Director;
                        partnerExist.Email = partner.Email;
						partnerExist.PhoneNumber = partner.PhoneNumber;
						partnerExist.Raiting = partner.Raiting;
						partnerExist.PartnerType = partner.PartnerType;
						db.SaveChanges();
					}
                }
            }
        }
		private void PartnersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            try
            {
                Partner partner = (Partner)PartnersListBox.SelectedItem;
                if(partner != null)
                {
                    var editWindow = new EditPartnerWindow(partner);
                    if(editWindow.ShowDialog() == true)
                    {
                        UpdatePartnerDB(editWindow.partnerModel);
                        partners.Clear();
						partners = GetAllPartnerDB();
                        PartnersListBox.ItemsSource = partners;
					}
                }
            }
            catch(Exception ex)
            {
                SetErrorMessage(ex.Message.ToString());
            }
		}
	}
}