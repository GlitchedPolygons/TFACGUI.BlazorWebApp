# TFACGUI
## Web-based variant

TFAC GUI is a 2FA (Two-Factor Authentication) token generator GUI.

It currently supports the following setups:

* TOTP
  * Hashing algorithm
    * SHA-1 (default)
    * SHA-256
    * SHA-512
  * Token generation interval
    * `30` seconds (default)
    * Any amount of seconds between `1` and `60`
  * Token length
    * `6` digits
    * Any amount of digits between `1` and `10`
  * Custom labelling of TOTP config entries (can be changed retro-actively)
* Import / export of (encrypted) backups of the 2FA key chain
 
30 seconds with SHA-1 is the de-facto standard for most implementations of 2FA ([Google Auth even ignores most of the parameters when set differently](https://github.com/google/google-authenticator/wiki/Key-Uri-Format#algorithm))

It's a spiritual successor to [TFAC GUI](https://github.com/GlitchedPolygons/TFACGUI), which is essentially the same thing that I wrote in C some time ago, but way, waaay more lightweight and much less portable compared to this. 
This here only carries its name as a legacy, because it no longer uses the previously utilized C-library [TFAC](https://github.com/GlitchedPolygons/TFAC) that was powering the native [TFAC GUI](https://github.com/GlitchedPolygons/TFACGUI).

This 2FA GUI is written using Blazor WebAssembly and functions 100% statically, zero-knowledge and client-side only. 

It has a [`.webmanifest`](https://github.com/GlitchedPolygons/TFACGUI.BlazorWebApp/blob/master/TFACGUI.BlazorWebApp/wwwroot/tfacgui.webmanifest) file that makes it [installable as a PWA](https://developer.mozilla.org/en-US/docs/Web/Progressive_web_apps/Guides/Installing) on smartphones and computers.

User data is stored in [`localStorage`](https://developer.mozilla.org/en-US/docs/Web/API/Window/localStorage) but can be purged with a button click, and is only ever exported out of the app's context via the export functionality, which requires you to encrypt the exported data with a password.

Hope you enjoy, cheers :D

### Screenshot

![TFAC GUI Blazor WebAssembly](https://api.files.glitchedpolygons.com/api/v1/files/tfacgui-blazor-wasm-screenshot-01.png)
