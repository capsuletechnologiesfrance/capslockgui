   M S B A M L   `   `   `  ����C  ?CAPSlock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CAPSlockCAPSlock  5          CAPSlock.CAPSSnapshot   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CAPSlock     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      
�������   MaterialDesignFont#���   5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $	��142 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5!   
   �� $��2��5"      $��32��5#      $��
50,60,50,9q�5$       �� Padding$ 	10,2,10,5q�5%      $��Center=�5&      ���	#FF6684A2
�������$��1q�5)       �� CornerRadius$ 5��5*      ._�5+      �� -   5        $��txtContents��5,      $��	11,0,10,0q�5-      ���	#FF6684A2$��0q�5/      |�.  $��20(�51      
�������$��SNAPSHOT��53      54      �� 56   
   $��1��57      $��0��58      $	��600��59      $	��300��5:      $��20,20,20,20q�5;      $��Stretch=�5<      $��Stretch=�5=      $��Center=�5>      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Foreground
 �   �   Mode$ Custom=�5@      
�������$��22(�5B      $��Last backup��5C      .��5D      �� .@�5E      �� -   5        $��lastSlot��5F      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �$��15(�5H      $5��/Lastest backup of the VMs is available in slot ��5I      5J      5K      �� 5M   
   $��1��5N      $��1��5O      $	��600��5P      $	��300��5Q      $��20,20,20,20q�5R      $��Stretch=�5S      $��Stretch=�5T      $��Center=�5U      
 �   �$ Custom=�5W      
�������$��22(�5Y      $��Create snapshot��5Z      .��5[      �� .@�5\      �� -   5        $��os��5]      $��15(�5^      $�� ��5_      5`      5a      �� 5c   
   $��2��5d      $��0��5e      $	��600��5f      $	��300��5g      $��20,20,20,20q�5h      $��Stretch=�5i      $��Stretch=�5j      $��Center=�5k      
 �   �$ Custom=�5m      
�������$��22(�5o      $��Restore��5p      .��5q      �� .@�5r      �� -   5        $��	Selection��5s      5u      5v      5w      �� 5y   
   -   5        $��6��5z      $��2��5{      $��0,0,0,50q�5|      $��	30,0,30,0q�5}      $��Center=�5~      $��Bottom=�5      +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 5��5�      ���	#FF9F9F9F$��0q�5�      $��Right=�5�      $��Make Snapshot of all VM��5�      
������� # MaterialDesignRaisedLightButton#��[ 5�      
 � Cursor$

 Hand��6`   {�5�      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�5�      5�      5�      