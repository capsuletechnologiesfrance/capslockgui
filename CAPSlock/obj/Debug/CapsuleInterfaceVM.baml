   M S B A M L   `   `   `  ����C  ?CAPSlock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CAPSlockCAPSlock  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      !    CAPSlock.CapsuleInterfaceVM   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CAPSlock     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      0sys&clr-namespace:System;assembly=mscorlib  5	      -   5          � Title$  Interface CAPSVM��5
      $
��1070��5      $	��600��5      $	��890��5      $	��450��5      
�������   MaterialDesignFont#���   5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � 	Resources 5        	bouton_VM ! MaterialDesignPaperDarkButton �� BasedOn �� 
TargetType �� Property	 �� Value
 �� RelativeSource �� AncestorType  
badgeStyle%  MaterialDesignThemes.Wpf.Badged0  *MaterialDesignThemes.Wpf.PackIconExtension   Size  badgeStyleTrue��%`  &	       7  &	 �    &	 �    �� 5   
   8   " ��5      .�5       -   5        �� 5!       � ��$	 31��6'   �� 5"       � ��$		 100��6)   �� 5#       � ��$		 100��6)   �� 5$       � ��$	 1q�6(   �� 5%       � ��$	 10,0,0,0q�6'   �� 5&       � ��
	 �����6+   �� 5'       � ��
	 �����6,   �� 5(       � ��
	 �   �6+   �� 5*       � {�	 6*   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+" �5+      �� 5,   
   "  6#   .�5-      ��  � ��$	 0,1,0,0q�6'   �� 5.       �@ Badge	 6&     $ 0X��� 5/       �@ BadgeBackground
	 �  ��60   50      �� 52   
   "  6'   .�53      ��  � ��$	 0,1,0,0q�6'   �� 54       �@ Badge	 6&     $ 0X��� 55       �@ BadgeBackground
	 � d �60   56      57      '  !System.Windows.Shell.WindowChrome   WindowChrome 59        5:   
      CaptionHeight$ 0Q�6   .��5<      �  � ColumnDefinitions 5>   
   �� 5?      -   5         ��Name$ Colonne1��5?      $	��250 �61   �� 5@      -   5        $ Colonne2��5@      $��* �61    � RowDefinitions 5B   
   .+�5E   
   �� $��0��5F      $��	-13,0,0,0q�5G      $��Center=�5H      $��Hidden=�5I      $��Visible=�5J      .��5K      �� -   5         ��Name$
 Navi��5L      $��0��5M      $��0��5N       J� Effect 5O      -  'System.Windows.Media.Effects.BlurEffect  5P      -   5        	PanelBlur��   
KernelType$ Gaussian=�5R         Radius$ 0Q�5S      ��5U      �� 5V       �� 
StartPoint$ 0.5,0&�6*    �� EndPoint$ 0.5,1&�6=   .��5W      �  � Offset$ 0.929Q�6'    � Color$ 	#FF382B2B��66   � 5X      $ 0.333Q�6'   $ 	#FF6684A2��66   5Y      .+�5[      �� -   5         ��Name$ HostName��5\      $
��0,25q�5]      $��Center=�5^      $��15(�5_      $
��Bold"�5`      
�������$�� ��5b      �� 5d      -   5         ��Name$ overviewButton��5e      $	��200��5f      $��	10,0,0,15q�5g      $��Center=�5h      $
��Left=�5i      
�������
�������$��Overview��5m       � Cursor$
 Hand��5n      ���	#DD000000{�5p      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL�9� 5r      -	   5         9�Name$ 
vmexpander��5s      $��
30,0,20,20q�5t      
�������
���   �$��RightToLeft=�5w      $��14(�5x      $��Medium"�5y        CustomExpander#��[ 5z      ��5|      �� 5}      $��52,0,0,0q�6$   $��Virtual machine��66    � LayoutTransform 5      �� 5�   "    �� Angle$ 0Q�62   5�      .��5�      �� -
   5        $ panel��5�      $��
24,8,24,16q�5�      $��LeftToRight=�5�      .+�5�      �� -   5        $ 
AddMachine��5�      $��0,0,0,0q�5�      $��Center=�5�      +  %MaterialDesignThemes.Wpf.RippleAssist    Feedback
  ���� 
���   �  MaterialDesignIconButton#��[ 5�      {�5�      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL�.��5�      '  !MaterialDesignThemes.Wpf.PackIcon  !   Kind$! PlusCircleOutline=�66   5�      �� 5�      -   5        " ��Name$" list_VM��5�      $	��133��5�      
������   ListBoxStyle1#��[ 5�      5�      5�      �� 5�      -   5        $ snapshotButton��5�      $	��200��5�      $��	10,0,0,15q�5�      $��Center=�5�      $
��Left=�5�      
�������
�������$��Snapshot��5�      $
 Hand��5�      ���	#DD000000{�5�      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL��� 5�      -   5        $��Terminal��5�      $	��200��5�      $��	10,0,0,15q�5�      $��Center=�5�      $
��Left=�5�      
�������
�������$��Terminal��5�      ���	#DD000000{�5�      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL��� 5�      -   5        $ logOutButton��5�      $
��0,30q�5�      $��	10,5,10,5q�5�      $��Center=�5�      $��Bottom=�5�      $��Center=�5�      +  %MaterialDesignThemes.Wpf.ButtonAssist#   CornerRadius$# 5��5�      ���	#FFA42626$��Logout��5�      $
 Hand��5�      ��5�      �� *CornerRadius+5�      �� 5�      $��0��5�      $��20,0,10,-180q�5�      $��Center=�5�      $��Bottom=�5�      $��Version 1.0 @CAPSlock��5�      $��14(�5�      $
��Bold"�5�      
�������5�      5�       5�      ��%X   (��       5�      *,*SystemParameters.VerticalScrollBarWidthKey+)X�6   5Q�6^   5�      5�      �� 5�   
   -   5        $ ��Name$$ contentControl��5�      $��1��5�      $��Stretch=�5�      �� 5�   
   -   5        $��1��5�      $��20��5�      $��20��5�      $��	0,10,40,0q�5�      $��Right=�5�      $	��Top=�5�      
������ $��X��5�      ��5�      �� 5�      % �� ImageSource$'% !Image/check-box-outline-blank.png��6   5�      �� 5�   
   -   5        $��1��5�      $��20��5�      $��20��5�      $��	0,10,10,0q�5�      $��Right=�5�      $	��Top=�5�      
������ ��5�      �� 5�      $% Image/close.png��6   5     �� 5  
   -   5        $��1��5     $��20��5     $��20��5     $��0,5,70,0q�5	     $��Right=�5
     $	��Top=�5     
������ $��X��5     ��5     �� 5     $% Image/minimize.png��6   5     5     5     