
$(document).ready(function(){

	

	/*
		- Initialize Chameleon Lifecycle
		- All callback functions are optional.
			- If you are not using a callback, remove it for extra preformance.
	*/
	
	chameleon.widget(
					
					{	
						
						//Triggered every time the widget loads.
						onLoad:function()
						{	
							$("#chameleon-widget").html("This is a template for building widgets");		
						},
						
						//Triggered the first time the widget is created.
						onCreate:function()
						{	
							//		
						},
						
						//Triggered everytime Chameleon resumes	(comes back into focus).				
						onResume:function()
						{
							//
						},
						
						//Triggered every time Chameleon pauses (goes out of focus).
						onPause:function()
						{
							//
						},
						
						//Triggered every time the size of the widget changes.
						onLayout:function()
						{
							//	
						},
						
						//Triggered when the user scrolls the widget to it's top.
						onScrollTop:function()
						{
							//
						},
						
						//Triggered when the user scrolls the widget away from it's top.
						onScrollElsewhere:function()
						{
							//
						},
						
						//Triggered when the user enters dashboard edit mode.
						onLayoutModeStart:function()
						{
							//					
							
						},
						
						//Triggered when the user exits dashboard edit mode.
						onLayoutModeComplete:function()
						{
							//
						},
						
						//Triggered when the status of network availability changes.
						onConnectionAvailableChanged:function(available)
						{
							//
						},
						
						//Triggered when the user taps the configure button in the widget title bar.
						onConfigure:function()
						{
							chameleon.promptHTML({url:"settings.html"});						
						},
						
						
						//Triggered when the user taps the widget titlebar.
						onTitleBar:function()
						{
							//
						},
						
						//Triggered when the user taps the refresh button on the widget title bar.
						onRefresh:function()
						{
							//
							
						},
						
						
						//Triggered when the user taps the action button on the widget title bar.
						onAction:function()
						{
							//
							
						},
						
						//Triggered every time the widget loads, but not in Chameleon.				
						notChameleon:function()
						{
							$("#chameleon-widget").html("This is a template for building widgets");	
						},
						
					}
	);
	
	
	
	
	
});





