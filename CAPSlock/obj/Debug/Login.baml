   M S B A M L   `   `   `  ����C  ?CAPSlock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CAPSlockCAPSlock  5	          CAPSlock.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CAPSlock     5	      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � Title$  Capsule Technologies��5      $	��600��5      $	��670��5      $	��600��5      $	��450��5         MaterialDesignPaper#���   5        MaterialDesignFont#���  5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6   .��5"      �  � RowDefinitions 5%   
   �� 5&      $��* �6   �� 5'      $��60 �6    � ColumnDefinitions 5*   
   �� 5+      $	��230 �6   �� 5,      $��* �6   .+�50   
   �� $��2��6   $��0��6"   ._�51      �� $��Stretch=�52      $��Stretch=�53      $&�� Image/blur-blue-gray-iphone5.jpg��54      $
��Fill=�55      56      �� 59   
   $��0��5:      $��0��5;      $��	10,0,10,0q�5<      $��Center=�5=      $��Center=�5>      $��19(�5?      $
��Bold"�5@      ���	#DDFFFFFF$%��Welcome on CentOS Linux CAPS-OS��5B      	 �� TextAlignment$	 Center=�5C      $
��Wrap=�5D      �� 5Q   
   $��0��5R      $��1��5S      $	��150��5T      $��80��5U      $��10,5,0,0q�5V      $
��Left=�5W      $	��Top=�5X      $ ��Image/capsule_logo_top.png��5Y      �� 5[   
   $��1��5\      $��2��5]      $��1��5^      $��0,0,0,0q�5_      $��Stretch=�5`      $	��Top=�5a      
�������5b      �� 5d   
   -   5        
 ��Name$
 IPBox��5e      $��1��5f      $	��500��5g      $��80,-220,80,0q�5h      $��Stretch=�5i      $��Center=�5j      )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �   �   Hint$ 
IP Address��5l      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   � % !MaterialDesignFloatingHintTextBox#��[ 5n       � Cursor$ IBeam��6H   �� 5p   
   -   5        $
 userBox��5q      $��1��5r      $	��500��5s      $��80,-100,80,0q�5t      $��Stretch=�5u      $��Center=�5v      
 �   �$ Username��5x      
 �   �#��[ 5z      G� 5   
   -   5         G�Name$ FloatingPasswordBox��5�      $��1��5�      $	��500��5�      $��
80,20,80,0q�5�      $��Stretch=�5�      $��Center=�5�      
 �   �$ Password��5�      
 �   �
������  G� PasswordChar$	 •��5�       ) %MaterialDesignFloatingHintPasswordBox#��[ 5�      �� 5�   
   -   5        $��PasswordUnmask��5�      $��1��5�      $	��500��5�      $��
80,20,80,0q�5�      $��Stretch=�5�      $��Center=�5�      
 �   �$ Password��5�      
 �   �#��[ 5�      $y�Hidden=�5�      �� 5�   
   -   5         ��Name$ checkBox_showPassword��5�      $��1��5�      $��18��5�      $��18��5�      $��70,110,80,0q�5�      $��Center=�5�      $��Center=�5�      ��5�      �� 5�       �� 
TargetType" d�6"   .R�5�      ��  �� Orientation$ 
Horizontal=�6!   .+�5�      �� ��5�      �� 5�   "   .�5�   &   ��  �� Property � �� �� Value$ Image\eye.png��6E    �� Triggers 5�   &   �� 5�   *    �� Binding 66   �� *	IsChecked+ �� RelativeSource ��  �� AncestorType" d� �� Value True6�   .a�5�   .   ��  � ��$ Image\eye-off.png��6M   5�   +   5�   #   5�      �� 5�      $��5,0,0,0q�6+   #��z��6<   5�      5�      5�      �� 5�   
   -   5        $ 
RememberMe��5�      $��1��5�      $��70,165,80,0q�5�      $��Center=�5�      $��Center=�5�      
���   �
���   �$��Remember me��5�      �� 5�   
   -   5         ��Name$
 btnC��5�      $��1��5�      $��	0,250,0,0q�5�      $��Center=�5�      $��Center=�5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5�      ���	#FF40B73A���	#FF40B73A . *MaterialDesignOutlinedSecondaryLightButton#��[ 5�      $
 Hand��6Q   {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5�      �� $��Login��6   5�      �� 5�   
   -	   5        $��1��5�      $��20��5�      $��20��5�      $��	0,10,10,0q�5�      $��Right=�5�      $	��Top=�5�      
������ ��5�      �� 5�       �� ImageSource$ Image/close.png��6   5�      �� 5�   
   -
   5        $��1��5�      $��20��5�      $��20��5�      $��	0,10,40,0q�5�      $��Right=�5�      $	��Top=�5�      
������ $��X��5�      ��5�      �� 5�      $' !Image/check-box-outline-blank.png��6   5�      �� 5�   
   -   5        $��1��5�      $��20��5�      $��20��5�      $��0,5,70,0q�5�      $��Right=�5�      $	��Top=�5�      
������ $��X��5�      ��5      �� 5     $ Image/minimize.png��6   5     5     5     