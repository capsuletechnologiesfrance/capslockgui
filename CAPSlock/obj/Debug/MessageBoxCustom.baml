   M S B A M L   `   `   `  ����  CAPSlock    CAPSlock.MessageBoxCustom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � Title$  MessageBoxWindow��5   	   $	��220��6"   $	��500��62   $	��220��6A   $	��500��6Q    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   
������� � 
ResizeMode$ 	CanResize=�5	   	    � Topmost .  � ShowInTaskbar .     MaterialDesignBody#���   5   	   $��Regular"�5   	   $��10(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   	   CaptionHeight$	 0Q�6   6+   .��5      � 
 � ColumnDefinitions
 5   
   �� 5      $
��197* �6   �� 5      $
��295* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  -   5          Name$ 
cardHeader��5      ���	#FF6684A2���	#FF6684A2$��0��6a   $��10q�6n   $��0q�6{   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6�    ! PrimaryHueDarkForegroundBrush#���  6�   $y�Visible=�6�   $��2��6  .��5      �� .+�5      �� -   5         ��Name$ txtTitle��5      $��Center=�6.   $��Stretch=�6K      MaterialDesignTitleTextBlock#���  6g   $��20(�6�   Message Title6�   5       5!      �� 5"   
   $��Right=�6   $��0,5,5,0q�62   $	��Top=�6D   $��1��6\   .+�5#      �� -   5         ��Name$ btnClose��5#   -   ���	#FF6684A2$��35��6V   $��35��6a   
�������
���iii� * &MaterialDesignFloatingActionDarkButton#��[ 6�   .��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6*   5%      5&      � 5'   
   $��1��6   $��2��6   .+�5(      � $��20q�6    5)      �� 5*      $
��auto �6$   �� 5+      $
��auto �6$   �� 5,      $��* �6$   .+�5/      � $��0��6    50      �� 51      $
��auto �6(   �� 52      $��* �6(   .+�56      �� -   5        $ 
txtMessage��56       $��Center=�66   $��0��6U   $��10q�6b   $��20(�6o     MaterialDesignTextBlock#��[ 6~   59      � 5:      $��1��6   $��0,20,0,5q�6$   
 5;      �� 5<      $��* �6+   �� 5=      $
��auto �6+   �� 5>      $
��auto �6+   �� 5?      $��* �6+   .+�5B      �� -   5        $ btnOk��5B      
��� d �+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��6C   $��0q�6�   $��1��6�     MaterialDesignRaisedButton#��[ 6�   $��5q�6�   $
��Auto��6�   $��Ok��6�   �� 5C      -   5        $ 	btnCancel��5C      ���	#FF6684A2���	#FF6684A2$��2��6w   #��[ 6�   $��5q�6�   $	��100��6�   $��Cancel��6�   �� 5D      -   5        $ btnYes��5D      
��� d �$ 5��6D   $��0q�6�   $��1��6�   #��[ 6�   $��10q�6�   $��5,5,5,5q�6�   $
��Auto��6�   $�� ��6  �� 5E      -   5        $ btnNo��5E      ���	#FFC23F3F$ 5��6C   $��0q�6�   $��2��6�   #��[ 6�   $��0q�6�   $��5,5,5,5q�6�   $
��Auto��6�   $�� ��6  5F      5H      5I      5J      5K      