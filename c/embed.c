/*
... TRUTH is the WAY to LIFE with G_D ... GIVE "REAL" CREDIT "REAL" REWARDS to those most deserving ... WORD. ... yQu knQw hQw we dQ ... We DQ ... WE DQ ...

http://heavycoder.com/tutorials/lua_embed.php
http://mirror.linux-ia64.org/gnu/gcc/releases/gcc-10.2.0/
https://www.lua.org/download.html
https://github.com/LOVE2d/LOVE/blob/master/license.txt
https://www.lua.org/license.html
https://gcc.gnu.org/onlinedocs/libstdc++/manual/license.html

"GCC RUNTIME LIBRARY EXCEPTION

Version 3.1, 31 March 2009

Copyright (C) 2009 Free Software Foundation, Inc.

Everyone is permitted to copy and distribute verbatim copies of this
license document, but changing it is not allowed.

This GCC Runtime Library Exception ("Exception") is an additional
permission under section 7 of the GNU General Public License, version
3 ("GPLv3"). It applies to a given file (the "Runtime Library") that
bears a notice placed by the copyright holder of the file stating that
the file is governed by GPLv3 along with this Exception.

When you use GCC to compile a program, GCC may combine portions of
certain GCC header files and runtime libraries with the compiled
program. The purpose of this Exception is to allow compilation of
non-GPL (including proprietary) programs to use, in this way, the
header files and runtime libraries covered by this Exception."

... wel.com ladies and Qentlemen ... this is 'smart' ... 
https://www.youtube.com/watch?v=HNGaa5Opfmc
... and now PLEASE RISE THE SINQINQ QF QUR NATIQNAL ANTHEM ... BATTER UP ..!

and for a little more yaya ... ja ja ja ... LOVE ... 

https://LOVE2d.org/
LOVE
https://github.com/LOVE2d/LOVE

https://github.com/stepelu/lua-ljsqlite3

https://github.com/stepelu/lua-sci

https://github.com/ledgetech/lua-resty-http

https://github.com/daurnimator/lua-http

"MAKE A WAY" ... see you back 'home' ... PROMISE.
*/
#include <stdlib.h>
#include <stdio.h>

/* Include the Lua API header files. */
#include <lua.h>
#include <lauxlib.h>
#include <lualib.h>

int main(void)
{
	/* Declare the Lua libraries we wish to use. */
	/* Note: If you are opening and running a file containing Lua code */
	/* using 'lua_dofile(l, "myfile.lua") - you must delcare all the libraries */
	/* used in that file here also. */
	static const luaL_reg lualibs[] =
	{
        	{ "base",       luaopen_base },
        	{ NULL,         NULL }
	};

	/* A function to open up all the Lua libraries you declared above. */
	static void openlualibs(lua_State *l)
	{
        	const luaL_reg *lib;

      		for (lib = lualibs; lib->func != NULL; lib++)
		{
                	lib->func(l);
                	lua_settop(l, 0);
        	}
	}

	/* Declare a Lua State, open the Lua State and load the libraries (see above). */
	lua_State *l;
	l = lua_open();
	openlualibs(l);

	/* You can do what you want here. Note: Remember to update the libraries used (see above) */
	/* if you add to your program and use new Lua libraries. */
	/* In the lines below, I load and run the Lua code contained in the file */
	/* "script.lua". */
	/* Plus print some text directly from C. */
	printf("This line in directly from C\n\n");
	lua_dofile(l, "script.lua");
	printf("\nBack to C again\n\n");

	/* Remember to destroy the Lua State */
	lua_close(l);

	return 0;
}
