GfmSharp [![Build status](https://ci.appveyor.com/api/projects/status/5xt2axubv7vp64qx)](https://ci.appveyor.com/project/ablanchet/gfmsharp)
========

Is for Github Flavored Markdown *sharp*.

It's just a tiny async .NET wrapper created to call the GFM service in order to convert markdown to html.

How to use it ?
---------------

### You just want to parse your input by the markdown syntax
	string content = await GfmSharp.GetHtml( "here is your MD input" );

### You want to parse you input by the GFM syntax ?
	string content = await GfmSharp.GetHtml( new GfmSharpMessage { Text = "here is your MD input", Mode = GfmSharpMessage.Modes.Gfm } );

For more informations
---------------------
For more informations :

* see the unit tests
* or the service api documentation ([http://developer.github.com/v3/markdown/](http://developer.github.com/v3/markdown/))
* Or create an issue / pull request
