   M S B A M L   `   `   `  ����I  EMedia Lejatszo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Media_LejatszoMedia_Lejatszo  5   	       Media_Lejatszo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Media_Lejatszo     5   	   -   5          �Name$  Music_Player��5   	    � Title$ Zenelejátszó��5   	   $��615.092��6   $	��446��6/    � 
ResizeMode$ CanMinimize=�6;    � Icon$ favicon.ico��6U   .��5	      �  � ColumnDefinitions 5
   
   �� 5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF4396F9��6    � Offset$ 0Q�61   � 5      $ 	#FF7A889C��6   $ 1Q�61   5      .+�5   
   �� -   5        	 ��Name$
	 open��5      $
��🎶��6   $
��Left=�6,   $��	31,10,0,0q�6G   $	��Top=�6Z   $��46��6r   $��26(�6�   
 J� RenderTransformOrigin$	
 1,0&�6�   $��50��6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   -   5         ��Name$ teszt��5      $�� ��6   $
��Left=�6*   $��
190,70,0,0q�6E   $	��Top=�6Y   $��16(�6q   $	��144��6   �� 5   
   -   5        $
	 play��5      $��▶️��6   $
��Left=�6,   $��155,486,0,0q�6G   $	��Top=�6\   $��28��6t   $��18(�6   $��34��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $	 pause��5      $��II��6    $
��Left=�6-   $��190,486,0,0q�6H   $	��Top=�6]   $��28��6u   $��18(�6�   $��34��6�   $
��Bold"�6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $
	 next��5      $��>>��6   $
��Left=�62   $��256,481,0,0q�6M   $	��Top=�6b   $��38��6z   $��24(�6�   $��39��6�   $
��Bold"�6�   $
 4.026,0.941&�6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   -   5        $	 previous��5      $��<<��6#   $
��Left=�66   $��110,481,0,0q�6Q   $	��Top=�6f   $��38��6~   $��24(�6�   $��39��6�   $
��Bold"�6�   ��6�   Z� ��6�   Z� �� 5   
   -   5         ��Name$
 list��5      $
��Left=�6    $	��374��6;   $��	34,70,0,0q�6H   $	��Top=�6[   $	��348��6s   ���	#7FA6A6A6��6�   Z� 6�   �� 5   
   -	   5         ��Name$ slider��5      $
��Left=�6!   $��
34,525,0,0q�6<   $	��Top=�6P   $	��351��6h   ���	#00000000���	#00000000��6�   Z� 6�   �� 5   
   -
   5        $
	 stop��5      $	��⬛��6   $
��Left=�6+   $��223,486,0,0q�6F   $	��Top=�6[   $��28��6s   $��18(�6~   $��34��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $ 	timelabel��5      $��00:00 / 00:00��6#   $
��Left=�6;   $��145,540,0,0q�6V   $	��Top=�6k   $��18(�6�   $	��120��6�   �� 5   
   -   5        $	 delete��5      $��🗑️��6!   $
��Left=�6/   $��
345,16,0,0q�6J   $	��Top=�6^   $��37��6v   $��24(�6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $
	 save��5      $
��💾��6   $
��Left=�6,   $��	97,14,0,0q�6G   $	��Top=�6Z   $��34��6r   $��26(�6�   $��36��6�   $
 -0.206,0.361&�6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   -   5        $
	 load��5      $
��📂��6   $
��Left=�6,   $��
155,11,0,0q�6G   $	��Top=�6[   $��58��6s   $��30(�6�   ��6�   Z� ��6�   Z� 6�   �� 5    
   -   5        $ volume��5       $
��Left=�6!   $��281,203,-106,0q�6<   $	��Top=�6T   $	��263��6l   $��22��6x   $
 0.5,0.5&�6�    � SmallChange$ 1Q�6�    � Maximum$ 1Q�6�    � LargeChange$	 0.1Q�6�   z�5!      V� 5"      .~�5#      �� �� 5$      �� 5%       �� Angle$ -89.901Q�6&   T� 5&      5'      5)      �� 5*   
   -   5        $	 cim��5*      $�� ��6   $
��Left=�6(   $��
34,444,0,0q�6C   $	��Top=�6W   $��14(�6o   $	��348��6}   �� 5+   
   -   5        $	 repeat��5+      $
��🔁��6!   $
��Left=�6.   $��314,479,0,0q�6I   $	��Top=�6^   $��45��6v   $��30(�6�   ��6�   Z� ��6�   Z� �� 5,   
   -   5        $	 
onerepeate��5,      $
��🔂��6%   $
��Left=�62   $��314,479,0,0q�6M   $	��Top=�6b   $��45��6z   $��30(�6�   ��6�   Z� ��6�   Z� �� 5-   
   -   5        $	 volumeup��5-      $	��➕��6#   $
��Left=�6/   $��
396,50,0,0q�6J   $	��Top=�6^   $��29��6v   $��16(�6�   $
��Bold"�6�   $��27��6�   ��6�   Z� ��6�   Z� 6�   �� 5.   
   -   5        $	 volumeup_Copy��5.      $	��➖��6(   $
��Left=�64   $��401,355,0,0q�6O   $	��Top=�6d   $��24��6|   $��16(�6�   $
��Bold"�6�   $��25��6�   $
 0.5,0.5&�6�   $��Segoe UI Black)�6  ��6�   Z� ��6�   Z� z�5/      V� 50      .~�51      �� �� 52      �� 53      $ -178.777Q�6&   T� 54      55      57      58      59      