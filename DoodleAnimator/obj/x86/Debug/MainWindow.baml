   M S B A M L   `   `   `  ����I  EDoodleAnimator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DoodleAnimatorDoodleAnimator  5          DoodleAnimator.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:DoodleAnimator     5      a ]DevExpress.Xpf.Core.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      c _DevExpress.Xpf.Ribbon.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      Fdxbh;http://schemas.devexpress.com/winfx/2008/xaml/bars/internal  5	      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5
      d `DevExpress.Xpf.Docking.v12.1, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxd5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      -   5          � Title$  Doodle Animator��5      $	��700��6   $
��1100��6*    J� SnapsToDevicePixels .  � UseLayoutRounding . &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ Office2010Black 5       � WindowState$ 	Maximized=�6P    � 	Resources 5      ��%    5      .��5      $  DevExpress.Xpf.Bars.BarManager  -   5          Name$ 
barManager��5      =  7DevExpress.Xpf.Bars.Helpers.BlendHelperForBarsAndRibbon   IsDesignControl .    Items 5   
   '  !DevExpress.Xpf.Bars.BarButtonItem  5      -   5        	  Name$	 bInfo��5       !  DevExpress.Xpf.Bars.BarItem
   Content)  #DevExpress.Xpf.Core.ObjectConverter$

 Info 6/      Glyph$! Images/Icons/info-16x16.png��6>      
LargeGlyph$! Images/Icons/info-32x32.png��6b     5      -   5        $	 bCopy��5       $

 Copy 6/   $! Images/Icons/copy-16x16.png��6>   $! Images/Icons/copy-32x32.png��6b     5      -   5        $	 bPaste��5       $
 Paste 60   $" Images/Icons/paste-16x16.png��6@   $" Images/Icons/paste-32x32.png��6e     5      -   5        $
	 bNew��5       $	
 New 6.   $  Images/Icons/new-16x16.png��6<   $  Images/Icons/New-32x32.png��6_   6�     5      -   5        $	 bPrint��5       $
 Print 60   $" Images/Icons/print-16x16.png��6@   $" Images/Icons/print-32x32.png��6e     5      -   5        $	 bOpen��5       $

 Open 6/   $! Images/Icons/open-16x16.png��6>   $! Images/Icons/open-32x32.png��6b   6�     5      -	   5        $	 bSave��5       $

 Save 6/   $! Images/Icons/save-16x16.png��6>   $! Images/Icons/save-32x32.png��6b   6�     5      -
   5        $	 bClose��5       $
 Close 60   $" Images/Icons/close-16x16.png��6@   $" Images/Icons/close-32x32.png��6e   6�     5      -   5        $
	 bCut��5       $	
 Cut 6.   $! /Images/Icons/cut-16x16.png��6<   $! /Images/Icons/cut-32x32.png��6`     5      -   5        $	 bSelect��5       $
 Select 61   $# Images/Icons/select-16x16.png��6B   $# Images/Icons/select-32x32.png��6h   6�     5       -   5        $	 bPencil��5        $
 Pencil 61   $# Images/Icons/pencil-16x16.png��6B   $# Images/Icons/pencil-32x32.png��6h   6�     5!      -   5        $	 bEraserSmall��5!       $
 Small 66   $# Images/Icons/eraser-16x16.png��6F   $# Images/Icons/eraser-32x32.png��6l   6�     5"      -   5        $	 bEraserLarge��5"       $
 Large 66   $# Images/Icons/eraser-16x16.png��6F   $# Images/Icons/eraser-32x32.png��6l   6�   $  DevExpress.Xpf.Bars.BarSubItem  5#      -   5          Name$ bEraser��5#      $
 Eraser 6.   $# Images/Icons/eraser-16x16.png��6?   $# Images/Icons/eraser-32x32.png��6e      	ItemLinks 5$      +	  %DevExpress.Xpf.Bars.BarButtonItemLink	  5%      -   5         �Name$ bEraserSmallLink��5%   ]   %
  DevExpress.Xpf.Bars.BarItemLink 
  BarItemName$ bEraserSmall��6,    
  UserGlyphSize$ Small=�6G   6]   	  5&      -   5        $ bEraserLargeLink��5&   ]   $ bEraserLarge��6,   $ Large=�6G   6]   5(        5*      -   5        $	 bClear��5*       $
 Clear 60   $" Images/Icons/clear-16x16.png��6@   $" Images/Icons/clear-32x32.png��6e   6�     5+      -   5        $	 bPlay��5+       $

 Play 6/   $! Images/Icons/play-16x16.png��6>   $! Images/Icons/play-32x32.png��6b   6�     5,      -   5        $	 bPause��5,       $
 Pause 60   $" Images/Icons/pause-16x16.png��6@   $" Images/Icons/pause-32x32.png��6e   6�     5-      -   5        $	 bStop��5-       $

 Stop 6/   $! Images/Icons/stop-16x16.png��6>   $! Images/Icons/stop-32x32.png��6b   6�     5.      -   5        $	 bImport��5.       $
 Import 61   $# Images/Icons/import-16x16.png��6B   $# Images/Icons/import-32x32.png��6h   6�   %  DevExpress.Xpf.Bars.BarEditItem  5/      -   5          Name$ txtFPS��5/      $
 
Velocidad: 6.      Content2$	 fps 6D      	EditValue$ 10 6S      Description$ Fotogramas por segundo 6b      	EditWidth$ 30Q�6�      EditHorizontalAlignment$ CenterX�6�      Manager 50        51      $��Center=�6%   $��Center=�6B      EditSettings 53      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  54      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings   DisplayFormat$	 ###��6+      AllowNullInput .     NullText$ 1��6V   !   HorizontalContentAlignment$ Right=�6c   56      '  !DevExpress.Xpf.Bars.BarStaticItem  57      -   5        $ barStaticItem1��57         58      -   5        $ barStaticItem2��58   9   $
 barStaticItem2 6    69   ._�5;   
   ]� .+�5<      )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ ribbonControl1��5<          RibbonStyle$ 
Office2007=�68    . $	��Top=�6�   !    ApplicationButtonLargeIcon$6  0/DoodleAnimator;component/Images/paint_brush.png��6�   !   ApplicationMenu! 5=      /  )DevExpress.Xpf.Ribbon.ApplicationMenuInfo  5>      "   RightPaneWidth$	" 280Q�6.   #   ShowRightPane# .  $   	ItemLinks$ 5?      	  5@      $
 bNew��64   	  5A      $ bOpen��64   	  5B      $ bImport��64   	  5C      $ bSave��64   .  (DevExpress.Xpf.Bars.BarItemLinkSeparator  5D      69   	  5E      $ bInfo��64   	  5F      $ bClose��64   5P      %   
Categories.% 5W      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase&   Pages.& 5X      &   DevExpress.Xpf.Ribbon.RibbonPage  -   5        $
 Home��5X   %   '   Caption$
' Home 61   (   Groups.( 5Y      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup  )   Caption$
) File��6.   *   	ItemLinks* 5Z      	  5[   "   $
 bNew��68   	  5\   "   $ bOpen��68   	  5]   "   $ bImport��68   	  5^   "   $ bSave��68   	  5_   "   $ bClose��68   5e        5f      $) Image��6.   * 5g      	  5h   "   $ bSelect��68   	  5i   "   $ bPencil��68   (  "DevExpress.Xpf.Bars.BarSubItemLink  5j   "   $ bEraser��65   + 
  RibbonStyle$+ Large=�6K   	  5k   "   $
 bCut��68   	  5l   "   $ bCopy��68   	  5m   "   $ bPaste��68   	  5n   "   $ bClear��68   5p        5q      $) 	Animation��6.   * 5r      	  5s   "   $ bPlay��68   	  5t   "   $ bPause��68   	  5u   "   $ bStop��68     5v   "   +  %DevExpress.Xpf.Bars.BarStaticItemLink  5w   "   $ barStaticItem1��68   )  #DevExpress.Xpf.Bars.BarEditItemLink  5x   "   $ txtFPS��66   5z      5{      5|      5�      .  (DevExpress.Xpf.Docking.DockLayoutManager  5�      -   5        ,  Name$, dockLayoutManager��5�   $   -   
LayoutRoot.- 5�      (  "DevExpress.Xpf.Docking.LayoutGroup  .   Items.. 5�        /   Orientation$/ Vertical=�6&   +  %DevExpress.Xpf.Docking.BaseLayoutItem0   	ItemWidth$0 3* �6>   .. 5�      (  "DevExpress.Xpf.Docking.LayoutPanel  1   Caption$1 Panel��6*   2   
ItemHeight$2 1.65* �6:   (  "DevExpress.Xpf.Docking.ContentItem3   Content.3 5�      �� -   5        $��
inkCanvas1��5�   (   5�        5�      -   5        4  Name$4 Bottom��5�   S   $/ 
Horizontal=�6*   $2 80 �6C   $��Bottom=�6a   .. 5�        -    5        $4 TimeLine��5�   S   $1 TimeLine��6.   $0 1.65* �6A   5   
AllowClose5 .  .3 5�   "   �� -!   5        $��
stackPanel��5�   n   
�������$��Stretch=�6D   $
��Auto��6`   .+�5�   &   �� -"   5        $��slider��5�   -   6 �� IsSnapToTickEnabled6 . $
��Left=�6V   $��29��6�   $��12��6�   $	��Top=�6�   $��Bottom=�6�   �� 5�   &   -#   5        $��listboxTimeLine��5�   b   $��25��6#  $��Bottom=�6/  7 �� SelectedIndex7 6.   �� *Value+8 �� ElementName$8 slider����5�   *   �� 5�   .   .R�5�   2   �� $��
stackpanel��6i   9 K� IsItemsHost9 . : �� Orientation$: 
Horizontal=�6P   6i   5�   /   5�   '   5�   #   5�        5�      -$   5        $4 ActionsFrames��5�   O   $1 Frames��6.   $	0 185 �6?   5 .  .3 5�   "   � -%   5        $��grid1��5�   '   .+�5�   &   �� -&   5        $��btnAdd��5�   �   $��28��6-   $
��Left=�69   $
��Left=�6T   $��	2,14,0,12q�6v   $��0,0,0,0q�6�   $	��Top=�6�   $��28��6�   .��5�   *   �� $3��-/DoodleAnimator;component/Images/add-icon.png��60   $��Uniform=�6g   5�   '   �� 5�   &   -'   5        $��	btnRemove��5�   �   $��28��6-   $
��Left=�69   $
��Left=�6T   $��
31,14,0,12q�6v   $��0,0,0,0q�6�   $	��Top=�6�   $��28��6�   .��5�   *   �� $6��0/DoodleAnimator;component/Images/remove-icon.png��60   $��Uniform=�6j   5�   '   �� 5�   &   -(   5        $��btnCut��5�   �   $��28��6-   $
��Left=�69   $
��Left=�6T   $��
64,14,0,12q�6v   $��0,0,0,0q�6�   $	��Top=�6�   $��28��6�   .��5�   *   �� $3��-/DoodleAnimator;component/Images/Cut-icon.png��60   $��Uniform=�6g   5�   '   �� 5�   &   -)   5        $��btnCopy��5�   �   $��28��6-   $
��Left=�69   $
��Left=�6T   $��
92,14,0,12q�6v   $��0,0,0,0q�6�   $	��Top=�6�   $��28��6�   .��5�   *   �� $;��5/DoodleAnimator;component/Images/Action-copy-icon.png��60   $
��Fill=�6o   5�   '   �� 5�   &   -*   5        $��btnDuplicate��5�   �   $��28��6-   $
��Left=�69   $
��Left=�6T   $��121,14,0,12q�6v   $��0,0,0,0q�6�   $	��Top=�6�   $��28��6�   .��5�   *   �� $<��6/DoodleAnimator;component/Images/duplicate-icon-md.png��60   $��UniformToFill=�6p   5�   '   �� 5�   &   -+   5        $��btnPaste��5�   �   $��28��6-   $
��Left=�69   $
��Left=�6T   $��150,14,0,12q�6v   $��0,0,0,0q�6�   $	��Top=�6�   $��28��6�   .��5�   *   �� $<��6/DoodleAnimator;component/Images/Action-paste-icon.png��60   $
��Fill=�6p   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      