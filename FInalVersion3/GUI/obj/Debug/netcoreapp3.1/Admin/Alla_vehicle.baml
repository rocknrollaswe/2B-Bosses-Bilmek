   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Pages	GUI.Pages  5          GUI.Pages.Alla_vehicle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Pages     5        N� Title$  Alla_vehicle��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6#   $��BILAR��60   $��16(�6?   $��
0, 0, 5, 0q�6M   $��	Agency FB)�5      ���	#FFFF2200$��2,2,2,2q�5      .��5      � $��0��6   $��0��6#    5      �� 5      $��3* �6'   �� 5      $��5* �6'   .+�5!      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $��Center=�6R   .+�5"      �� -   5         ��Name$ LB_Car��5"      $	��120��6/   $	��200��6;   $��5,1,5,5q�6H   $��Center=�6Y   
�������$
��Bold"�6�   
���   �$��14(�6�   ��5#      �� 5$       �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��5%   "   �  � Color$ 	#FF993030��6/    � Offset$ 0Q�6A   � 5&   "   $ 	#FFDA8A8A��6/   $ 1Q�6A   5'      5)      5*      �� 5,      $��1��6   $��	10,10,5,5q�6-   $
��Left=�6@   $��Center=�6[   .+�5-      �  5.      �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54      .+�57      �� $��0��6%   $	��230��62   .+�58      �� -   5        	 ��Name$	 tb_brand_car��58   &   $��-- Märke --��6=   
 �� 
IsReadOnly$

 True��6P   $��5,5,5,5q�6b    �� TextWrapping$
 Wrap=�59      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5:      
�������$��12(�6C   .��6R   ��5;   "   �� 5<   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5=   *   � $ Black��67   � 5>   *   $ 	#FF434343��67   $ 1Q�6I   5?   '   .��5@   6   5A      5B      �� 5C      $��1��6%   $	��230��62   .+�5D      �� -   5        $	 tb_model_car��5D   &   $��-- Modell --��6=   $

 True��6Q   $��5,5,5,5q�6c   $
 Wrap=�5E      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5F      
�������$��12(�6C   .��6R   ��5G   "   �� 5H   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5I   *   � $ Black��67   � 5J   *   $ 	#FF434343��67   $ 1Q�6I   5K   '   .��5L   6   5M      5N      �� 5O      $��2��6%   $	��230��62   .+�5P      �� -   5        $	 tb_caseID_car��5P   &   $��-- ÄrendeID --��6>   $

 True��6T   $��5,5,5,5q�6f   $
 Wrap=�5Q      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5R      
�������$��12(�6C   .��6R   ��5S   "   �� 5T   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5U   *   � $ Black��67   � 5V   *   $ 	#FF434343��67   $ 1Q�6I   5W   '   .��5X   6   5Y      5Z      �� 5[      $��3��6%   $	��231��62   .+�5\      �� -   5        $	 tb_mekaniknamn_car��5\   &   $!��-- Aktiv Mekanikers Namn --��6C   $

 True��6f   $��5,5,5,5q�6x   $
 Wrap=�5]   !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5^      
�������$��12(�6C   .��6R   ��5_   "   �� 5`   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5a   *   � $ Black��67   � 5b   *   $ 	#FF434343��67   $ 1Q�6I   5c   '   .��5d   6   5e      5f      �� 5g      $��4��6%   $	��230��62   .+�5h      �� -   5        $	 Tb_mekanikid_car��5h   &   $��-- Mekaniker ID --��6A   $��5,1,5,5q�6\   $
 Wrap=�5i      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5j      
�������$��12(�6C   .��6R   ��5k   "   �� 5l   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5m   *   � $ Black��67   � 5n   *   $ 	#FF434343��67   $ 1Q�6I   5o   '   .��5p   6   5q      5r      �� 5s      $��5��6%   $	��230��62   .+�5t      �� -   5        $	 tb_workstatus_car��5t   &   $&�� -- Fordonets Nuvarande Status --��6B   $

 True��6j   $��5,5,5,5q�6|   $
 Wrap=�5u   !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5v      
�������$��12(�6C   .��6R   ��5w   "   �� 5x   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5y   *   � $ Black��67   � 5z   *   $ 	#FF434343��67   $ 1Q�6I   5{   '   .��5|   6   5}      5~      5      5�      5�      5�      � 5�   
   $��0��6   $��1��6   .+�5�      �� $��0��6   $��0��6'   $��	LASTBILAR��64   $��16(�6G   $��
0, 0, 5, 0q�6V   $��	Agency FB)�5�      ���	#FF24FDF4$��2,2,2,2q�5�      .��5�      � $��0��6   $��0��6'    5�      �� 5�      $��3* �6+   �� 5�      $��5* �6+   .+�5�      �� $ 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   .+�5�      �� -   5        $ LB_Truck��5�   "   $	��120��65   $	��200��6A   $��5,1,5,5q�6N   $��Right=�6_   $��Center=�6{   
���   �
�������$��14(�6�   ��5�      �� 5�   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5�   &   � $ 	#FF283C3E��63   $ 0Q�6E   � 5�   &   $ 	#FF83ADB2��63   $ 1Q�6E   5�   #   5�      5�      �� 5�      $��1��6!   $��5,10,5,5q�61   $
��Left=�6C   $��Center=�6^   .+�5�      �  5�      �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   .+�5�      �� $��0��6)   .+�5�   "   �� -	   5        $	 Tb_brand_truck��5�   *   $��-- Märke --��6C   $

 True��6V   $��5,5,5,5q�6h   $
 Wrap=�5�      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�      
�������$��12(�6C   .��6R   ��5�   &   �� 5�   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�   .   � $ Black��6;   � 5�   .   $ 	#FF434343��6;   $ 1Q�6M   5�   +   .��5�   :   5�   #   5�      �� 5�      $��1��6)   $	��230��66   $
��Left=�6B   .+�5�   "   �� -
   5        $	 Tb_model_truck��5�   *   $��-- Modell --��6C   $

 True��6W   $��5,5,5,5q�6i   $
 Wrap=�5�      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�      
�������$��12(�6C   $��Stretch=�6Q   .��6p   ��5�   &   �� 5�   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�   .   � $ Black��6;   � 5�   .   $ 	#FF434343��6;   $ 1Q�6M   5�   +   .��5�   :   5�   #   5�      �� 5�      $��2��6)   $	��230��66   $
��Left=�6B   .+�5�   "   �� -   5        $	 Tb_caseid_truck��5�   *   $��-- ÄrendeID --��6D   $

 True��6Z   $��5,5,5,5q�6l   $
 Wrap=�5�      $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�      
�������$��12(�6C   .��6R   ��5�   &   �� 5�   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�   .   � $ Black��6;   � 5�   .   $ 	#FF434343��6;   $ 1Q�6M   5�   +   .��5�   :   5�   #   5�      �� 5�      $��3��6)   .+�5�   "   �� -   5        $	 TB_mekaniknamn_truck��5�   *   $!��-- Aktiv Mekanikers Namn --��6I   $

 True��6l   $��5,5,5,5q�6~   $
 Wrap=�5�   !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5�      
�������$��12(�6C   .��6R   ��5�   &   �� 5�   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�   .   � $ Black��6;   � 5�   .   $ 	#FF434343��6;   $ 1Q�6M   5�   +   .��5�   :   5�   #   5�      �� 5�      $��4��6)   .+�5�   "   �� -   5        $	 TB_mekanikid_truck��5�   *   $��-- Mekaniker ID --��6G   $��5,1,5,5q�6b   $
 Wrap=�5�      $	��214��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�      
�������$��12(�6C   .��6R   ��5�   &   �� 5�   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�   .   � $ Black��6;   � 5�   .   $ 	#FF434343��6;   $ 1Q�6M   5�   +   .��5�   :   5�   #   5�      �� 5�      $��5��6)   .+�5�   "   �� -   5        $	 TB_workstatus_truck��5�   *   $&�� -- Fordonets Nuvarande Status --��6H   $

 True��6p   $��5,5,5,5q�6�   $
 Wrap=�5�   !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5�      
�������$��12(�6C   .��6R   ��5�   &   �� 5�   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�   .   � $ Black��6;   � 5�   .   $ 	#FF434343��6;   $ 1Q�6M   5�   +   .��5�   :   5�   #   5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6   $��0��6   .+�5�      �� $��0��6   $��0��6'   $��MOTORCYKLAR��64   $��16(�6I   $��
0, 0, 5, 0q�6X   $��	Agency FB)�5�      ���	#FFF2FB34$��2,2,2,2q�5�      .��5�      � $��0��6   $��0��6'    5      �� 5     $��3* �6+   �� 5     $��5* �6+   .+�5     �� $ 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   .+�5     �� -   5        $ LB_MC��5  "   $	��120��62   $	��200��6>   $��Right=�6K   $��5,1,5,5q�6g   $��Center=�6x   
���   �
�������$��14(�6�   ��5     �� 5  "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5	  &   � $ 	#FF878722��63   $ 0Q�6E   � 5
  &   $ 	#FFF57C28��63   $ 1Q�6E   5  #   5     5     �� 5     $��1��6!   $��5,10,5,5q�61   $
��Left=�6C   $��Center=�6^   .+�5     �  5     �� 5  "   �� 5  "   �� 5  "   �� 5  "   �� 5  "   �� 5  "   .+�5     �� $��0��6)   .+�5  "   �� -   5        $	 TB_brand_mc��5  *   $��-- Märke --��6@   $

 True��6S   $��5,5,5,5q�6e   $
 Wrap=�5     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5     
�������$��12(�6C   .��6R   ��5  &   �� 5  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5   .   � $ Black��6;   � 5!  .   $ 	#FF434343��6;   $ 1Q�6M   5"  +   .��5#  :   5$  #   5%     �� 5&     $��1��6)   .+�5'  "   �� -   5        $	 TB_model_mc��5'  *   $��-- Modell --��6@   $

 True��6T   $��5,5,5,5q�6f   $
 Wrap=�5(     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5)     
�������$��12(�6C   .��6R   ��5*  &   �� 5+  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5,  .   � $ Black��6;   � 5-  .   $ 	#FF434343��6;   $ 1Q�6M   5.  +   .��5/  :   50  #   51     �� 52     $��2��6)   $	��230��66   .+�53  "   �� -   5        $	 TB_caseid_mc��53  *   $��-- ÄrendeID --��6A   $

 True��6W   $��5,5,5,5q�6i   $
 Wrap=�54     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�55     
�������$��12(�6C   .��6R   ��56  &   �� 57  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��58  .   � $ Black��6;   � 59  .   $ 	#FF434343��6;   $ 1Q�6M   5:  +   .��5;  :   5<  #   5=     �� 5>     -   5         ��Name$ LB_Mekaniknamn_mc��5>  )   $��3��6D   .+�5?  "   �� -   5        $	 TB_mekaniknamn_mc��5?  *   $!��-- Aktiv Mekanikers Namn --��6F   $

 True��6i   $��5,5,5,5q�6{   $
 Wrap=�5@  !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5A     
�������$��12(�6C   .��6R   ��5B  &   �� 5C  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5D  .   � $ Black��6;   � 5E  .   $ 	#FF434343��6;   $ 1Q�6M   5F  +   .��5G  :   5H  #   5I     �� 5J     $��4��6)   $	��230��66   .+�5K  "   �� -   5        $	 TB_mekanikid_mc��5K  *   $��-- Mekaniker ID --��6D   $��5,1,5,5q�6_   $
 Wrap=�5L     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5M     
�������$��12(�6C   .��6R   ��5N  &   �� 5O  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5P  .   � $ Black��6;   � 5Q  .   $ 	#FF434343��6;   $ 1Q�6M   5R  +   .��5S  :   5T  #   5U     �� 5W     $��5��6)   .+�5X  "   �� -   5        $	 TB_workstatus_mc��5X  *   $&�� -- Fordonets Nuvarande Status --��6E   $

 True��6m   $��5,5,5,5q�6   $
 Wrap=�5Y  !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5Z     
�������$��12(�6C   .��6R   ��5[  &   �� 5\  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5]  .   � $ Black��6;   � 5^  .   $ 	#FF434343��6;   $ 1Q�6M   5_  +   .��5`  :   5a  #   5b     5c     5d     5e     5f     5g     � 5n  
   $��1��6   $��1��6   .+�5o     �� $��0��6   $��0��6'   $��BUSSAR��64   $��16(�6D   $��
0, 0, 5, 0q�6S   $��	Agency FB)�5p     ���	#FF89EE43$��2,2,2,2q�5q     .��5r     � $��0��6   $��0��6'    5s     �� 5t     $��3* �6+   �� 5u     $��5* �6+   .+�5x     �� $ 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   .+�5y     �� -   5        $ LB_Bus��5y  "   $	��120��63   $	��200��6?   $��5,1,5,5q�6L   $��Right=�6]   $��Center=�6y   
�������
���   ���5z     �� 5{  "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5|  &   � $ 	#FF183404��63   � 5}  &   $ 	#FF66EE09��63   $
 0.98Q�6E   5~  #   5�     5�     �� 5�     $��1��6!   $��5,10,5,5q�61   $
��Left=�6C   $��Center=�6^   .+�5�     �  5�     �� 5�  "   �� 5�  "   �� 5�  "   �� 5�  "   �� 5�  "   �� 5�  "   .+�5�     �� $��0��6)   .+�5�  "   �� -   5        $	 Tb_brand_bus��5�  *   $��-- Märke --��6A   $

 True��6T   $��5,5,5,5q�6f   $
 Wrap=�5�     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�     
�������$��12(�6C   .��6R   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�  .   � $ Black��6;   � 5�  .   $ 	#FF434343��6;   $ 1Q�6M   5�  +   .��5�  :   5�  #   5�     �� 5�     $��1��6)   .+�5�  "   �� -   5        $	 TB_model_bus��5�  *   $��-- Modell --��6A   $

 True��6U   $��5,5,5,5q�6g   $
 Wrap=�5�     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�     
�������$��12(�6C   .��6R   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�  .   � $ Black��6;   � 5�  .   $ 	#FF434343��6;   $ 1Q�6M   5�  +   .��5�  :   5�  #   5�     �� 5�     $��2��6)   $	��230��66   .+�5�  "   �� -   5        $	 Tb_caseid_bus��5�  *   $��-- ÄrendeID --��6B   $

 True��6X   $��5,5,5,5q�6j   $
 Wrap=�5�     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�     
�������$��12(�6C   .��6R   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�  .   � $ Black��6;   � 5�  .   $ 	#FF434343��6;   $ 1Q�6M   5�  +   .��5�  :   5�  #   5�     �� 5�     $��3��6)   .+�5�  "   �� -   5        $	 Tb_mekaniknamn_bus��5�  *   $!��-- Aktiv Mekanikers Namn --��6G   $

 True��6j   $��5,5,5,5q�6|   $
 Wrap=�5�  !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5�     
�������$��12(�6C   .��6R   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�  .   � $ Black��6;   � 5�  .   $ 	#FF434343��6;   $ 1Q�6M   5�  +   .��5�  :   5�  #   5�     �� 5�     $��4��6)   .+�5�  "   �� -   5        $	 Tb_mekanikId_bus��5�  *   $��-- Mekaniker ID --��6E   $��5,1,5,5q�6`   $
 Wrap=�5�     $	��215��62   $��20��6>   $��Center=�6J   $��Center=�6n   $
��Bold"�5�     
�������$��12(�6C   .��6R   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�  .   � $ Black��6;   � 5�  .   $ 	#FF434343��6;   $ 1Q�6M   5�  +   .��5�  :   5�  #   5�     �� 5�     $��5��6)   $	��230��66   .+�5�  "   �� -   5        $	 Tb_workstatus_bus��5�  *   $&�� -- Fordonets Nuvarande Status --��6F   $

 True��6n   $��5,5,5,5q�6�   $
 Wrap=�5�  !   $	��215��65   $��20��6A   $��Center=�6M   $��Center=�6q   $
��Bold"�5�     
�������$��12(�6C   .��6R   ��5�  &   �� 5�  *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5�  .   � $ Black��6;   � 5�  .   $ 	#FF434343��6;   $ 1Q�6M   5�  +   .��5�  :   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     