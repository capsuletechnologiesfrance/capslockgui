   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a   CustomExpander  �� 
TargetType �� Property �� Value �� 
TargetType � RowDefinitions �� CornerRadius �� Padding  ListBoxStyle1  MaterialDesignBody �� RelativeSource �� AncestorLevel	 �� AncestorType0   *MaterialDesignThemes.Wpf.ListBoxItemAssist
 ��Name J� Opacity �� Property �� 	Converter=  7MaterialDesignThemes.Wpf.Converters.BrushRoundConverter   	HighValue   LowValue%  MaterialDesignThemes.Wpf.Ripple  Name   RecognizesAccessKey J� SnapsToDevicePixels   Feedback'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   
Storyboard   From   GeneratedEasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty	  W� To! g� Duration" �� Triggers# P� Property$ P� Value% �� Value& �� Binding' �� 
TargetName( ]� 
Conditions) �� Property* �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      %  &	        '�� �     &	 �    �� 5      "  9�6#   .�5   
   ��  � ��$	 0.5q�6,   �� 5   
    � ��$	 200��6"   �� 5   
    � ��$ 32��6&   �� 5	   
    � ��$ 9q�6$   �� 5
   
    � ��
 �   �6'   5      �� 5      "  ��6   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      �  5      �� 5      $
��Auto �6,   �� 5      $��* �6,   .+�5      �� $��0��5      $��0,0,0,10q�5      
�������
�������$��1q�5      $ 0,0,0,0��5      ._�5      �� $��Header��6/   ��. 6F   5      �� 5      $��2��5       $ 10q�5!      
�������
�������$��1q�5$      $ 5,5,5,5��5%      ._�5&      �� $��4q�6/   5'      5(      5)      5+      5,      �� 5.      "  ��6"   .�5/   
   ��  � ��
 ���� 6'   �� 50   
    � ��
 ���� 6(   �� 51   
    � ��$ 0q�6,   �� 52   
    � ��# �  6'   �� 53   
    � �� 54      �� 55      "  ��6   .�56      ��  � ��
 ���� 63   �� 57       � ��$ 0q�68   �� 58       � �� 6C   �� *HorizontalContentAlignment+ �� *FindAncestor+$ 1��"	 ���� 59       � �� 6A   �� *VerticalContentAlignment+ �� *FindAncestor+$ 1��"	 ���� 5:       � ��$ 8q�60   �� 5;       �@J�SnapsToDevicePixels . 6<   �� 5<       �@  ShowSelection .  6W   �� 5=       � �� 5>      �� 5?      " ��6.   .R�5@   "   �� #��z��5A   %   #��z��5B   %   #��z��5C   %   #��z��5D   %   #}�z}�5E   %   ._�5F   &   � .+�5G   *   �� $
 MouseOverBorder��61   $ 0Q�6J   ��5H   .   �� 5I   2    � �� 5J   6     5K   :   
 �����
 �   �6o   5M   3   5O   +   �� 5P   *   $
 SelectedBorder��61   $ 0Q�6I   ��5Q   .   �� 5R   2    � �� 5S   6     5T   :   
 �����
 �   �6o   5V   3   5X   +     5Y   *   $ Ripple��5Z   -   #��z��5[   -   #��z��5\   -   #��z��5]   -   #��z��5^   -   #��z��5_   -   |�.   .  # z 5b   -    5c   .   �� 5d   2    � �� 5e   6     5f   :   
 �����
 �   �6o   5h   3   5j   +   5k   '    5l   &     5m   *   CommonStates�� 5n   .     5o   2   $ 0:0:0.3D�5p   5   $ Normal��5s   5    5q   5   Z�  5r   5   Z�  5t   6     5u   :   $ EaseOut=�6E   5w   3   . 5y   .     
Normal��6:     5z   .   	MouseOver��. 5{   2   �� .��5|   6   W� $ MouseOverBorder��5}   9   $ Opacity�5~   9   $	  0.1X�5   9   $! 0D�5�   9   5�   3   5�   /     5�   .   Disabled��6:   5�   +     5�   *   SelectionStates�� 5�   .     5�   2   $ 0:0:0.6D�5�   5    5�   5   Z�  5�   5   Z�  5�   5   Z�  5�   5   Z� . 5�   .     Selected��. 5�   2   �� .��5�   6   W� $ SelectedBorder��5�   9   $ Opacity�5�   9   $
  0.18X�5�   9   $! 0D�5�   9   5�   3   5�   /     5�   .   
Unselected��6:     5�   .   SelectedUnfocused��. 5�   2   �� .��5�   6   W� $ SelectedBorder��5�   9   $ Opacity�5�   9   $
  0.03X�5�   9   $! 0D�5�   9   5�   3   5�   /   5�   +   5�   #   " 5�   "   P� 5�   &   # � {�$ .  . �5�   *   ��  �@J�Opacity$
 0.56Q�6D   5�   '   �� 5�   &   $% False��6�   & 62   �� *20(materialDesign:ListBoxItemAssist.ShowSelection)+ �� *Self+.a�5�   *   �� $' MouseOverBorder��61    � y�$ 	Collapsed=�6d   �� 5�   *   $' SelectedBorder��61    � y�$ 	Collapsed=�6c   �� 5�   *   $' Ripple��61    �@ Feedback
 ���� 6Y   5�   '   5�      5�      5�      5�      �� 5�   
    � ��$ Disabled=�6G   �� 5�   
    � ��$
 Auto=�6E   �� 5�   
    � �� . 6:   �� 5�   
    �@��PanningMode$
 Both=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � ��$ Center=�65   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $
 Bd��5�      #��z��5�      #��z��5�      #��z��5�       . ._�5�      �� #��z��6'   |�.  .��5�      �� # z 6-   5�      5�      " 5�      ]� 5�      ( 5�      �� 5�   "   ) �@��
IsGrouping* . 6B   �� 5�   "   ") �@%�IsVirtualizingWhenGrouping* .  6d   ./�5�      ��  � �� .  6N   5�      5�      5�      5�      5�      