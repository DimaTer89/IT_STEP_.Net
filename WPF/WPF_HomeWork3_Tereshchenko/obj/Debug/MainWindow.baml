   M S B A M L   `   `   `  ����U  QWPF_HomeWork3_Tereshchenko, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WPF_HomeWork3_TereshchenkoWPF_HomeWork3_Tereshchenko  5   	   +    %WPF_HomeWork3_Tereshchenko.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:WPF_HomeWork3_Tereshchenko     5   	     � Title$  	Rectangle��5   	   $	��350��6   $	��525��6(   $	��350��5	   	   $	��525��6   $	��350��5
   	   $	��525��6    � 	Resources 5       �� 
TargetType   
labelStyle �� Property �� Value*  $WPF_HomeWork3_Tereshchenko.Rectangle  myRectangle   Height   Widht  gradientBrush � Color � Offset��%�  &	        &	 �     &	     �� 5   
   " ��6   .�5      ��  � ��$ Vivaldi)�6+   �� 5       � ��$ 27(�6)   �� 5       � ��$ 17q�6'   �� 5       � ��$ Center=�69   �� 5       � ��$ Center=�6;   5        5   
   $ 5Q�6.   $ 20Q�69   
� 5   
   .��5      � $ Black��6   $ 0.021Q�6)   � 5      $
 Aqua��6   $ 0.665Q�6(   � 5      $
 Cyan��6   $ 0.946Q�6(   5      5      .��5      � #��[ 6    5   
     textBoxStyle  textBox1Style	 �� BasedOn��%�  &	       &	     7  �� 5      " ��6   .�5      ��  � ��$ 25q�6+   �� 5       � ��$ Vivaldi)�6/   �� 5       � ��$ 20(�6-   �� 5        � ��$ Center=�6=   �� 5!       � ��
 �  ��6/   �� 5"       � ��$ Oblique$�6.   5#      �� 5$      " ��6   8	   .�5&      ��  � ��$ Segoe UI Bold)�6/   �� 5'       � ��
 ��  �6/   �� 5(       �@��
IsReadOnly . 6/   5)      5*      
 � ColumnDefinitions
 5+   
   �� 5,      �� 5-      �� 5.      .+�50   
   �� $��0��6   .+�51      �� #��[  6   $��Height��68   �� 52      #��[  6   $��Widht��68   �� 53      #��[  6   $��Square��68   �� 54      #��[  6   $��	Perimeter��68   55      �� 56   
   $��1��6   .+�57      �� -   5         ��Name$ height��57      #��[ 6&   ��58      ��  �� Source# [  �� Path$ Height��� 59      -   5        $ widht��59      #��[ 6%   ��5:      �� # [ $ Widht��� 5;      -   5        $ square��5;      #��[ 6&   �� 5<      -   5        $ 	perimeter��5<      #��[ 6)   5=      �� 5>   
   $��2��6   .+�5?      �� -   5         ��Name$ caclulateButton��5?      $��	Calculate��6.   $
��Left=�6B   $��	27,98,0,0q�6]   $	��Top=�5@      $	��120��6-   $��45��69   5A      �� 5B      -   5        $ authorButton��5B      $��About Author��6+   $
��Left=�6B   $��
27,178,0,0q�6]   $	��Top=�5C      $	��120��6-   $��45��69   5D      5E      5F      5G      