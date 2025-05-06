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
using System.Windows.Shapes;
using WpfDemoZiaytdinova.Models;

namespace WpfDemoZiaytdinova
{
	public partial class EditPartnerWindow : Window
	{
		public Partner partnerModel = new Partner();
		public EditPartnerWindow(Partner partner)
		{
			InitializeComponent();
			try
			{
				partnerModel = partner;
				TypeComboBox.ItemsSource = GetAllPartnertType();
				InitFields(partnerModel);
			}
			catch(Exception e)
			{
				SetErrorMessage(e.Message);
			}
		}

		public void InitFields(Partner partner)
		{
			if (partner != null)
			{
				NameBox.Text = partner.Name;
				AddressBox.Text = partner.Address;
				INNBox.Text = partner.Inn;
				PhoneNumberBox.Text = partner.PhoneNumber;
				DirectorBox.Text = partner.Director;
				EmailBox.Text = partner.Email;
				RaitingBox.Text = partner.Raiting;
				foreach (PartnerType item in TypeComboBox.ItemsSource)
				{
					if (item.Id == partner.PartnerTypeId)
					{
						TypeComboBox.SelectedItem = item;
					}
				}
			}
		}

		public List<PartnerType> GetAllPartnertType()
		{
			try
			{
				using(var db = new AppDBContext())
				{
					var types = db.PartnerTypes.ToList();
					if (types != null)
					{
						return types;
					}
				}
				return null;
			}
			catch(Exception e)
			{
				SetErrorMessage(e.Message.ToString());
				return null;
			}
		}

		public void SetErrorMessage(string message)
		{
			MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (CheckValidationFields())
				{
					partnerModel.Name = NameBox.Text;
					partnerModel.Address = AddressBox.Text;
					partnerModel.Inn = INNBox.Text;
					partnerModel.Email = EmailBox.Text;
					partnerModel.Raiting = RaitingBox.Text;
					partnerModel.Director = DirectorBox.Text;
					partnerModel.PhoneNumber = PhoneNumberBox.Text;
					partnerModel.PartnerType = ((PartnerType)TypeComboBox.SelectedItem);
					DialogResult = true;
					Close();
				}
			}
			catch(Exception ex)
			{
				SetErrorMessage(ex.Message.ToString());
			}
		}

		private bool CheckValidationFields()
		{
			if (string.IsNullOrWhiteSpace(NameBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите наименование");
			}
			if (string.IsNullOrWhiteSpace(AddressBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите адрес");
			}
			if (string.IsNullOrWhiteSpace(INNBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите ИНН");
			}
			if (string.IsNullOrWhiteSpace(PhoneNumberBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите номер телефона");
			}
			if (string.IsNullOrWhiteSpace(DirectorBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите ФИО директора");
			}
			if (string.IsNullOrWhiteSpace(EmailBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите электронную почту");
			}
			if (!EmailBox.Text.Contains("@"))
			{
				throw new InvalidOperationException("Почта должна содержать @");
			}
			if (string.IsNullOrWhiteSpace(RaitingBox.Text))
			{
				throw new InvalidOperationException("Все поля должны быть заполнены. Введите рейтинг");
			}
			if (Convert.ToInt32(RaitingBox.Text) < 0 || Convert.ToInt32(RaitingBox.Text) > 20)
			{
				throw new InvalidOperationException("Рейтинг должен быть в диапазоне от 0 до 20");
			}
			return true;
		}
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
        }
    }
}
