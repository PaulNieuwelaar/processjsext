# Process.js Extensions - CRM 2013-D365 Custom Actions
[![download](https://user-images.githubusercontent.com/14048382/27844360-c7ea9670-6174-11e7-8658-80d356c1ba8f.png)](https://github.com/PaulNieuwelaar/processjsext/releases/download/v2.0/ProcessJSExtensions_2_0_0_0.zip) (v2.0) [<img align="right" src="https://user-images.githubusercontent.com/14048382/29433676-4eb13ea6-83f4-11e7-8c07-eca514b1b197.png"/>](https://github.com/PaulNieuwelaar/processjsext/wiki/Documentation)

This solution includes a bunch of sample Actions, which replicate some of the standard SDK messages, allowing you to call these easily from Process.js. The actual Actions are just wrappers for the real logic, which is all implemented in plugins (source code available). Check the Actions for the input and output parameters of each, and then call these actions using Process.js to try them out.

Check out [Process.js 2.0](https://github.com/PaulNieuwelaar/processjs) for examples on how to call these Actions (there's an example for "Retrieve"). You don't NEED Process.js to install this solution, so if you want to use something else to call the Actions, like the new WebApi (shudder), then you can still use these Actions without Process.js.

These Actions were mostly just created to test out the Entity and EntityCollection parameters I've recently added to v2 of Process.js, but since they might be useful to others, I'm releasing them here as an extra add-on.

Actions included are:
* Associate
* Create
* CreateMultiple (wanted to test EntityCollection input)
* Delete
* Disassociate
* Retrieve
* RetrieveMultiple
* SetState
* Update
* UpdateMultiple

The logical names to use when calling the actions are just "mag_" plus whatever above.

Check the [Documentation](https://github.com/PaulNieuwelaar/processjsext/wiki/Documentation) more info about what input/output parameters are required.

Each action includes a custom plugin with a plugin step registered against the action to perform all the logic, e.g. getting the input params, processing the request, and setting the output params.

Note that using actions to do, for example, a Create request, is probably a bit slower than doing a Create request purely through JavaScript (using SOAP or WebApi), since it's making a direct call to the CRM web service instead of calling an action which then executes the action request. However I haven't noticed any significant delays. And you can just display a nice [Notify.js](https://github.com/PaulNieuwelaar/notifyjs) spinner while it's processing. :)

Created by [Paul Nieuwelaar](http://paulnieuwelaar.wordpress.com) - [@paulnz1](https://twitter.com/paulnz1)  
Sponsored by [Magnetism Solutions - Dynamics CRM Specialists](http://www.magnetismsolutions.com)
