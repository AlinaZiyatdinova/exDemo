   M S B A M L   `   `   `  ����M  IWpfDemoZiaytdinova, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfDemoZiaytdinovaWpfDemoZiaytdinova  5   	   *    $WpfDemoZiaytdinova.EditPartnerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfDemoZiaytdinova     5   	     � Icon$%  /Images/Мастер пол.ico��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�5
   	    � Title$3 -Редактирование партнера��5   	   $	��450��6)   $	��800��66   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ 
Horizontal=�6   .+�5      �� $%��/Images/Мастер пол.png��6   $��50��64   $��10q�6@   �� 5      $&�� Данные о партнёре��6   $��20(�61   $��Center=�6?   $��Center=�6\   5      �� 5   
   $��Наименование��6   �� 5   
   -   5        $��NameBox��5      �� 5   
   $��Директор��6   �� 5   
   -   5        $��DirectorBox��5      �� 5   
   $��
Почта��6   �� 5   
   -   5        $��EmailBox��5      �� 5   
   $!��Номер телефона��6   �� 5   
   -   5        $��PhoneNumberBox��5      �� 5   
   $��
Адрес��6   �� 5   
   -   5        $��
AddressBox��5      �� 5   
   $��ИНН��6   �� 5   
   -   5        $��INNBox��5      �� 5   
   $��Рейтинг��6   �� 5   
   -   5        $��
RaitingBox��5      �� 5   
   $��Тип партнёра��6   �� 5    
   -   5        $��TypeComboBox��5        �� DisplayMemberPath$ TypeName��6'   �� 5!   
   $ 
Horizontal=�6   $��20q�6.   .+�5"      �� -	   5         ��Name$ 
SaveButton��5"      $��Сохранить��6)   $��5q�6=   6H   �� 5#      -
   5        $��CancelButton��5#      $��Отмена��6)   $��5q�6:   6E   5$      5%      5&      