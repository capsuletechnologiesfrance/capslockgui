   M S B A M L   `   `   `  ����C  ?CAPSlock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CAPSlockCAPSlock  5          CAPSlock.CAPSInformations   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CAPSlock     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      
�������   MaterialDesignFont#���   5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      �� -   5         ��Name$  contentControlInformations��5      .��5   
   �  � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $	��142 �6     � ColumnDefinitions 5      �� 5      �� 5      .+�5!      �� $��0��5"      $��2��5#      $��Center=�5$       �� Orientation$ 
Horizontal=�5%      .+�5&      �� -   5        $��VM��5'      $	��250��5(      $��0,60,0,0q�5)      $��Center=�5*      $	��Top=�5+      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5,      ���	#FF6684A2$��0q�5.      $��20(�50      
������� # MaterialDesignRaisedLightButton#��[ 53      {�52      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��54      �� 
�������$�� ��63   55      �� 56      $��2��57      $	��250��58      $��0,60,0,0q�59      $��Center=�5:      $	��Top=�5;      $ 5��5<      ���	#FF6684A2$��0q�5>      $��20(�5?      #��[ 5A      $y�	Collapsed=�5B      {�5@      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5C      �� 
�������$��Informations��63   5D      5E      �� 5F      $��1��5G      $��0��5H      $	��260��5I      $	��100��5J      $��20,20,20,20q�5K      $��Right=�5L      $��Stretch=�5M      $��Center=�5N      .  (MaterialDesignThemes.Wpf.ColorZoneAssist	   
Foreground
	 �����
   Mode$
 Custom=�5P      
�������$��15(�5R      
���   �$��Virtual machine name��5T      .��5U      �� -   5        $��nameVM��5V      $��Bottom=�5W      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �$��18(�5Y      $�� ��5Z      5[      �� 5\      $��1��5]      $��1��5^      $	��260��5_      $	��100��5`      $��20,20,20,20q�5a      $
��Left=�5b      $��Stretch=�5c      $��Center=�5d      
	 �����$
 Custom=�5f      
�������$��15(�5h      
���   �$��Current Status��5j      .��5k      �� -   5         ��Name$ Status��5l      $��Bottom=�5m      
 �   �$��15(�5o       �� 
IsReadOnly . $��Stopped��5q      5r      �� 5s      $��2��5t      $��1��5u      $	��260��5v      $	��100��5w      $��20,20,20,20q�5x      $
��Left=�5y      $��Stretch=�5z      $��Bottom=�5{      
	 �����$
 Custom=�5}      
�������$��15(�5      
���   �$��Number of CPUs��5�      .��5�      �� -   5        $
��proc��5�      $��Bottom=�5�      
 �   �$��18(�5�      $��3��5�      5�      �� 5�      $��2��5�      $��0��5�      $	��260��5�      $	��100��5�      $��20,20,20,20q�5�      $��Right=�5�      $��Stretch=�5�      $��Bottom=�5�      
	 �����$
 Custom=�5�      
�������$��15(�5�      
���   �$��Quantity of memory (MB)��5�      .��5�      �� -   5        $��memoire��5�      $��Bottom=�5�      
 �   �$��18(�5�      $
��2048��5�      5�      �� 5�      $��5��5�      $��2��5�      $��
50,25,50,0q�5�      $	��Top=�5�      
�������5�      �� 5�      $��5��5�      $��2��5�      $��Center=�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $��-145,5,30,50q�5�      $��	30,5,30,5q�5�      $ 5��5�      ���	#FF026500$��0q�5�      $
��Left=�5�      #��[ 5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5�      �� 
�������$��Confirm changes��63   5�      �� 5�      $��0,5,0,50q�5�      $��	30,0,30,0q�5�      $��Center=�5�      $ 5��5�      ���	#FFD98200$��0q�5�      #��[ 5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5�      �� 
�������$��Cancel��63   5�      �� 5�      -   5         ��Name$ Delete��5�      $��30,5,-175,50q�5�      $��	30,0,30,0q�5�      $ 5��5�      ���	#FFC23F3F$��0q�5�      $��Right=�5�      #��[ 5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5�      �� 
�������$��	Delete VM��63   5�      5�      5�      5�      5�      