   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Hello, World��5   	   $	��350��6   $	��500��6+   $	��350��67   $	��300��6G    � 	Resources 5	         MyBrush �� Color �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value	 �� BasedOn  
headerText  FontTextBox
 ]� 
Conditions �� Property �� Value��%�  &	        '��      7   '�� �    &	 w    7��&	 �    �� 5
   
   $
 Gold��6*   �� 5   
   " ��6   .�5      ��  � ��
 ��  �6+   �� 5       � ��$ 14(�6)   �� 5       � ��8   6+   �� 5       � ��$ Trebuchet MS)�6+   �� 5       � ��$ 10,15q�6'   �� 5       � ��
 �  ��6,   �� 5       � ��$ 2q�60   �� 5       � ��$ 5,3,3,5q�6(    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 � E��63   5      5      �� 5   
   " ��6   .�5      ��  � ��$ 11(�6)   �� 5       � ��$ Trebuchet MS)�6+   �� 5       � ��
 �����6+   5      �� 5   
   8	   " ��6B   .�5       ��  � ��$ 15(�6)   �� 5!       � ��$
 Bold"�6+   5"      �� 5#   
   �5$      �� 5%       � ��$ Calibri)�67   �� 5&       � ��$ 14(�65   �� 5'       � ��$ Center=�6E    5)      ]� 56      
 57      �� 58       �@J�	IsFocused . 6A   �� 59       �@J�IsMouseOver . 6C   /�5;      �� 5<       � ��
 �  ��6?   �� 5=       � ��
 ��  �6@   �� 5>       � ��$ 18(�6=   �� 5?       � ��$ 3q�6D   5A      5C      5D      .��5E      ]� .+�5F   
   o� $	��Top=�6   $
��left=�6%   .@�5G      m� $
��File��6   .@�5H      m� $��Launch��6    m� Command$! local:CustomCommands.Launch��6+   m� 5I      -   5        $
��Exit��5I      6)   5J      m� 5K      $
��Edit��6   .@�5L      m� $��Копировать��6   $
 Copy��6`    m� CommandTarget 6/   ��  �� ElementName$ 
MainWindow��6`   m� 5M      $��Вырезать��6   $	 Cut��6^    6-   �� $ 
MainWindow��6^   m� 5N      $��Вставить��6   $ Paste��6^    6-   �� $ 
MainWindow��6^   5O      5P      �� 5Q   
   -   5         ��Name$	 lbl��5Q      $��Center=�6   $	��Top=�6:   .��6O   
Пуск6U   �� 5R   
   -   5         ��Name$	 stb��5R      $��Bottom=�6!   .@�5S      �� -   5         ��Name$
 stb1��5S      .��5T      �� !Статусная панель6.   5U      �� 5V      �� 5W      -   5        $
 stb2��5W      .��5X      �� Online6$   5Y      �� 5Z      -   5        $
 stb3��5Z      .��5[      �� 6   5\      �� 5]      -   5        $
 stb4��5]      .��5^      �� -	   5         ��Name$ check��5^      .��6*   0.Разрешить открытие формы6D   5_      5`      � 5a   
   -
   5         � ColumnDefinitions 5b      �� 5c      $	��150 �6#   �� 5d      $��* �6#    � RowDefinitions 5f      �� 5g      $��* �6    �� 5h      $��* �6    �� 5i      $��* �6    .+�5k      �� -   5        $��setBut��5k      $��Set Name��6#   $
��Left=�66   $��0��6Q   $��0��6a   $	��Top=�6n   �� 5l      -   5        $��retBut��5l      $��Ret Name��6#   $
��Left=�66   $��0��6Q   $��1��6a   $	��Top=�6n   $��75��6�   �� 5m      -   5        $��setText��5m      $��Stretch=�6%   $��1��6C   $��0��6S    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   #��[ 6�   #��[  6�   �� 5n      -   5        $��retLabel��5n      $�� ��6$   $
��Left=�6/   $��1��6J   $��1��6Z   $	��Top=�6g    J� RenderTransformOrigin$ 0.581,-0.346&�6   $��59��6�   $	��255��6�   #��[  6�   �� 5o      -   5         ��Name$ New_Win��5o      $!��local:CustomCommands.Launch��6&   $��New Win��6L   $
��Left=�6^   $��0��6y   $��2��6�   $	��Top=�6�   $��75��6�   �� 5p      -   5         ��Name$ txtBlock��5p      $
��Wrap=�6*   $��1��6>   $��2��6N   $��	TextBlock��6[   $��10,15,10,15q�6l   5q      5r      5s      