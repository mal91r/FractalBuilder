   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��450��65   $	��800��6E   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   .+�5   
   �� $��10q�6   $��1��6   $��1��6*   $��10q�6:   
���   �
������� �� CornerRadius$ 10��6v    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.3Q�6#      
BlurRadius$ 25Q�61      ShadowDepth$ 3Q�6A   ._�5      � -   5         �Name$
 grid��5      5      5      � 5   
   $��1��6    5      �� 5      $��1* �6    �� 5       $��1* �6    �� 5!      $��1* �6    �� 5"      $��1* �6    .+�5%      �� -   5        	 ��Name$
	 Menu��5%   \   $��10q�6   $��Center=�6$   $��0��6A   $��45(�6N   $
��Menu��6j   �� 5'      -   5        $
	 Type��5'   )   $��0 0 0 0q�6   $
��Type��67   $��1��6C   $��Center=�6P   $	��Top=�6m   $��40(�6�   �� 5)      $��
10 0 10 10q�6   $��20��6+   $��1��67   
 �� Text$
 Фрактaл��6D   $��Stretch=�6S   $��Center=�6q   $��Bottom=�6�   .@�5*      �� -   5        $��Fracral Tree��5*      66   �� 5+      -   5        $��	Koch line��5+      63   �� 5,      -   5        $��Serp Carpet��5,      65   �� 5-      -   5        $��Serp Triangle��5-      67   �� 5.      -   5        $��
Cantor Set��5.      64   50      �� 52      -	   5        $
	 Deep��52   *   $��0 10 0 0q�6   $
��Deep��68   $��2��6D   $��Center=�6Q   $	��Top=�6n   $��40(�6�   54      �� 55      -
   5         ��Name$ 
sliderDeep��55   6   $��
10 0 10 10q�6   $��2��6)   $��Bottom=�6J    � Minimum$ 1Q�6e    � Maximum$ 10Q�6q    �� IsSnapToTickEnabled$
 True��6~    �� TickFrequency$ 1Q�6�   �� 57      -   5        $	 Color��57   )   $��0 0 0 0q�6   $��Color��68   $��3��6E   $��Center=�6R   $	��Top=�6o   $��40(�6�   59      �� 5:      -   5         ��Name$ changeColorButton��5:      $��10q�60   $��3��6<   $��Bottom=�6I   $��25��6d   $��Change��6p   $��15(�6�   5;      �� 5=   
   $	��500��6   $��0��6!   $��0��6.   $��2��6>   
���   �
������� 5>        5?      $	 0.3Q�6#   $ 25Q�61   $ 3Q�6A   ._�5B      �� -   5        $	 Title��5B   ^   $��Center=�6   $��Center=�63   $��35(�6P   $��FractalShower��6m   5C      5H      5J      