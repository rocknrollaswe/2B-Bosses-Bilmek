   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Pages	GUI.Pages  5          GUI.Pages.Profile   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Pages     5        N� Title$  Profile��5	      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      � $��0��6   .+�5      �  � RowDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6!   $��Center=�6.   $��Center=�6K   .+�5      �� $��1��6$   $�� Användare information ��64   $��2,2,2,2q�6U   
�������
���   �$��Center=�6�   $��Center=�6�   $��	Agency FB)�6�   $��20(�6�   $	��400��6�   .��5      � $��Center=�6#   $��Center=�6@    5   "   �� 5   &   �� 5   &   �� 5   &   �� 5   &   .+�5!   "   �� $��0��6-   .+�5"   &   � $	��132��6+   $	��380��68    5#   *   �� 5$   .   $��1* �6<   �� 5%   .   $��1* �6<   �� 5&   .   $��1* �6<   �� 5'   .   $��1* �6<    5)   *   �� 5*   .   �� 5+   .   .+�5.   *   � $��0��6/   $��0��6<    5/   .   �� 50   2   $
��113* �6C   �� 51   2   $	��37* �6C   .+�53   .   �� $��Användares namn :��64   
�������$��16(�6c   $��2��6q   54   +   � 55   *   $��0��6/   $��1��6<   .+�56   .   �� -   5         ��Name$ tb_username��56   4   $��Hittarde inge info��6I   
�������$��16(�6y   $��Right=�6�   $��0,0,10,0q�6�   57   +   � 5:   *   $��1��6/   $��0��6<    5;   .   �� 5<   2   $
��113* �6C   �� 5=   2   $	��37* �6C   .+�5?   .   �� $��Användares E-mail :��64   
�������$��16(�6e   $��2��6s   5@   +   � 5A   *   $��1��6/   $��1��6<   .+�5B   .   �� -   5        $ tb_useremail��5B   4   $��Hittarde inge info��6J   
�������$��16(�6z   $��Right=�6�   $��0,0,10,0q�6�   5C   +   � 5I   *   $��2��6/   $��0��6<    5J   .   �� 5K   2   $
��113* �6C   �� 5L   2   $	��37* �6C   .+�5N   .   �� $!��Användares födelsedatum :��64   
�������$��16(�6k   $��2��6y   5O   +   � 5P   *   $��2��6/   $��1��6<   .+�5Q   .   �� -   5        $ tb_userbirth��5Q   4   $��Hittarde inge info��6J   
�������$��16(�6z   $��Right=�6�   $��0,0,10,0q�6�   5R   +   � 5W   *   $��3��6/   $��0��6<    5X   .   �� 5Y   2   $
��113* �6C   �� 5Z   2   $	��37* �6C   .+�5\   .   �� $$��Slutdatum för anställning : ��64   
�������$��16(�6n   $��2��6|   5]   +   � 5^   *   $��3��6/   $��1��6<   .+�5_   .   �� -   5        $ tb_resignmentdate��5_   4   $��Hittarde inge info��6O   
�������$��16(�6   $��Right=�6�   $��0,0,10,0q�6�   5`   +   5e   '   5f   #   5h      5i      5j      �� 5m      $��1��6!   $��Center=�6.   $��Center=�6I   .+�5n      �� $"��Lägg till/ta bort kompetens��6#   $��1��6H   $��2,2,2,2q�6X   
�������
���   �$��Center=�6�   $��Center=�6�   $��	Agency FB)�6�   $��20(�6�   $	��400��6�   .��5o      � $��
29,20,0,20q�6#   $	��359��67   $
��Left=�6C   $��Center=�6^    5p   "   �� 5q   &   $
��1.3* �67   �� 5r   &   $��1* �67   �� 5s   &   $��1* �67    5u   "   �� 5v   &   �� 5w   &   .+�5y   "   �� $��0��6-   $��0��6:   $
��Left=�6J   .+�5z   &   �� -   5         ��Name$ 
Cb_Bromsar��5z   /   $��Bromsar��6C   
�������
�������$
��Bold"�6|   $
��Left=�6�   $��Center=�6�   $��16(�6�   ��5{   *   �� 5|   .    �� EndPoint$ 0.5,1&�6B    �� 
StartPoint$ 0.5,0&�6S   .��5}   2   �  � Color$ 	#FF072E14��6?   � 5~   2   $ 	#FF1B9F47��6?    � Offset$ 1Q�6Q   5   /   5�   '   5�   #   �� 5�   "   $��0��6-   $��1��6:   $
��Left=�6J   .+�5�   &   �� -   5        $ Cb_Motor��5�   /   $��Motor��6A   
�������
�������$
��Bold"�6x   $
��Left=�6�   $��Center=�6�   $��16(�6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $ 	#FF072E14��6?   � 5�   2   $ 	#FF1B9F47��6?   $ 1Q�6Q   5�   /   5�   '   5�   #   �� 5�   "   $��0��6-   $��2��6:   $
��Left=�6J   .+�5�   &   �� -   5        $ 	Cb_Kaross��5�   /   $��Kaross��6B   
�������
�������$
��Bold"�6z   $
��Left=�6�   $��Center=�6�   $��16(�6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $ 	#FF072E14��6?   � 5�   2   $ 	#FF1B9F47��6?   $ 1Q�6Q   5�   /   5�   '   5�   #   �� 5�   "   $��1��6-   $��0��6:   $��0,10,0,0q�6J   $
��Left=�6\   .+�5�   &   �� -   5        $ Cb_Vindruta��5�   /   $��Vindruta��6D   
�������
�������$
��Bold"�6~   $
��Left=�6�   $��Center=�6�   $��16(�6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $ 	#FF072E14��6?   � 5�   2   $ 	#FF1B9F47��6?   $ 1Q�6Q   5�   /   5�   '   5�   #   �� 5�   "   $��1��6-   $��1��6:   $��0,10,0,0q�6J   $
��Left=�6\   .+�5�   &   �� -	   5        $ Cb_wheel��5�   /   $��Däck��6A   
�������
�������$
��Bold"�6x   $
��Left=�6�   $��16(�6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $ 	#FF072E14��6?   � 5�   2   $ 	#FF1B9F47��6?   $ 1Q�6Q   5�   /   5�   '   5�   #   �� 5�   "   $��1��6-   $��2��6:   $
��Left=�6J   $��Bottom=�6e   .+�5�   &   �� -
   5        	 ��Name$	 BT_chnageSkills��5�   -   $��Ändra��6F   $��60��6V   $��Center=�6a   $��22��6~   
�������$��14(�6�   $
��Bold"�6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $ Black��6?   � 5�   2   $ 	#FF434343��6?   $ 1Q�6Q   5�   /   5�   '   5�   #   �� 5�   "   $��1��6-   $��2��6:   $
��Left=�6J   5�   #   5�      5�      5�      �� 5�      $��2��6!   .+�5�      �� $�� Pågående ärenden ��6#   $��1��6?   $��2,2,2,2q�6O   
�������
���   �$��Center=�6�   $��Center=�6�   $��	Agency FB)�6�   $��20(�6�   $	��400��6�   .��5�      �  5�   "   �� 5�   &   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   �� $��0��6-   .+�5�   &   �� $��Första Ärendet :��6,   
�������$��16(�6Z   $
��Left=�6h   $��0,0,10,0q�6�   $��Normal$�6�   5�   #   �� 5�   "   $��1��6-   .+�5�   &   �� -   5        $ tb_case1_Info��5�   ,   $"��Inga ärende tilldelat ännu��6C   
�������$��16(�6{   $��Center=�6�   $��0,0,10,0q�6�   5�   #   �� 5�   "   $��2��6-   .+�5�   &   �� $��Andra Ärendet :��6,   
�������$��16(�6Y   $
��Left=�6g   $��0,0,10,0q�6�   $��Normal$�6�   5�   #   �� 5�   "   $��3��6-   .+�5�   &   �� -   5        $ tb_case2_Info��5�   ,   $"��Inga ärende tilldelat ännu��6C   
�������$��16(�6{   $��Center=�6�   $��0,0,10,0q�6�   5�   #   5�      5�      5�      5�      5�      �� 5�      $��1��6   .+�5�      � $	��330��6   $��0,0,0,20q�6#    5�      �� 5�      $��6* �6+   �� 5�      $��* �6+   .+�5�      �� $��0��6   $��Totalt antal ärenden : ��6,   
�������$��Blackadder ITC)�6a   $��30(�6}   $��Center=�6�   $
��Bold"�6�   $��Center=�6�   $	��220��6�   6�   �� 5�      -   5        $ tb_usertotal_case��5�      $��1��67   $��0��6G   
�������$��20(�6f   $��Center=�6t   $��0,0,10,0q�6�   $
��Bold"�6�   $��	Agency FB)�6�   $��Center=�6�   5�      �� 5�      $��Avslutat ärende��6   $��0��64   $��2,2,2,2q�6D   
�������
���   �$��Center=�6�   $��Center=�6�   $��	Agency FB)�6�   $��20(�6�   .��5�      �  5�      �� 5�      $��1* �6,   �� 5�      $��1* �6,   �� 5      $��1* �6,   �� 5     $��1* �6,   �� 5     $��1* �6,   �� 5     $��1* �6,   �� 5     $��1* �6,   �� 5     $��1* �6,   .+�5	     �� $��0��6%   $��Center=�62   $��Center=�6O   $��5,5,5,5q�6j   .+�5
     �� -   5        
 ��Name$
 cb_finshed_case��5
  '   ${�False��6@    �� Text$" -- Välj avslutat ärende --��6R   $	��350��6t   $��35��6�    �� 
IsEditable$
 True��6�    �� 
IsReadOnly$
 True��6�   $��	Agency FB)�6�   $��14(�6�   $
��Bold"�6�   $��Center=�6�   $��Center=�6  5     5     �� 5     $��1��6%   $��5,5,5,5q�62   .+�5     �� -   5         ��Name$ tb_fordon_reg��5  &   $��-- Ärende Regnummer --��6=    �� TextWrapping$
 Wrap=�6[   $	��350��6o   $��35��6{   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   
������� �� 
IsReadOnly$
 True��6�   $��16(�6  .��6  ��5  "   �� 5  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5  *   � $ Black��67   � 5  *   $ 	#FFB13030��67   $ 1Q�6I   5  '   .��5  6   5     5     �� 5      $��2��6%   $��5,5,5,5q�62   .+�5!     �� -   5        $ tb_fordontyp��5!  &   $��-- Fordonets typ --��6<   $
 Wrap=�6W   $	��350��6k   $��35��6w   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   
�������$
 True��6�   $��16(�6   .��6  ��5"  "   �� 5#  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5$  *   � $ Black��67   � 5%  *   $ 	#FF434343��67   $ 1Q�6I   5&  '   .��5'  6   5(     5)     �� 5,     $��3��6%   $��5,5,5,5q�62   .+�5-     �� -   5        $ tb_fordonbrand��5-  &   $��-- Fordonets märke --��6>   $
 Wrap=�6[   $	��350��6o   $��35��6{   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   
�������$
 True��6�   $��16(�6  .��6  ��5.  "   �� 5/  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��50  *   � $ Black��67   � 51  *   $ 	#FF434343��67   $ 1Q�6I   52  '   .��53  6   54     55     �� 59     $��4��6%   $��5,5,5,5q�62   .+�5:     �� -   5        $ tb_fordonmodel��5:  &   $��-- Fordonets Modell --��6>   $
 Wrap=�6\   $	��350��6p   $��35��6|   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   
�������$
 True��6�   $��16(�6  .��6  ��5;  "   �� 5<  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5=  *   � $ Black��67   � 5>  *   $ 	#FF434343��67   $ 1Q�6I   5?  '   .��5@  6   5A     5B     �� 5H     $��5��6%   $��5,5,5,5q�62   .+�5I     �� -   5        $ 	tb_caseid��5I  &   $��-- Ärendenummer --��69   $
 Wrap=�6S   $	��350��6g   $��35��6s   $��Center=�6   $��Center=�6�   $
��Bold"�6�   
�������$
 True��6�   $��16(�6�   .��6  ��5J  "   �� 5K  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5L  *   � $ Black��67   � 5M  *   $ 	#FF434343��67   $ 1Q�6I   5N  '   .��5O  6   5P     5Q     �� 5U     $��6��6%   $��5,5,5,5q�62   .+�5V     �� -   5        $ tb_issue��5V  &   $��-- Ärendeproblem--��68   $
 Wrap=�6R   $	��350��6f   $��35��6r   $��Center=�6~   $��Center=�6�   $
��Bold"�6�   
�������$
 True��6�   $��16(�6�   .��6
  ��5W  "   �� 5X  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5Y  *   � $ Black��67   � 5Z  *   $ 	#FF434343��67   $ 1Q�6I   5[  '   .��5\  6   5]     5^     �� 5a     $��7��6%   $��5,5,5,5q�62   .+�5b     �� -   5        $ tb_comments��5b  &   $��--- Kommentarer ---��6;   $
 Wrap=�6V   $	��350��6j   $��35��6v   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   
�������$
 True��6�   $��16(�6�   .��6  ��5c  "   �� 5d  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5e  *   � $ Black��67   � 5f  *   $ 	#FF434343��67   $ 1Q�6I   5g  '   .��5h  6   5i     5j     5v     5w     5|     5}     5     5�     