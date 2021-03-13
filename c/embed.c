/*
... TRUTH is the WAY to LIFE with G_D ... GIVE "REAL" CREDIT "REAL" REWARDS to those most deserving ... WORD. ... yQu knQw hQw we dQ ... We DQ ... WE DQ ...
3 EASY STEPS .. STEP BY STEP:

1. READ THIS ARTICLE TO UNDERSTAND WHAT WE ARE DOING:
http://heavycoder.com/tutorials/lua_embed.php

2. DOWNLOAD THE GNC GCC FREE POWERFUL OPEN SOURCE FASTEST MACHINE INSTRUCTION PRODUCING "C" LANGUAGE COMPILER KNOWN here:
http://mirror.linux-ia64.org/gnu/gcc/releases/gcc-10.2.0/
 NOTE: if you download the gcc compiler above from the .zip file in this JohnEBoyBaby/i.Q github 'repository' directory then you will find there are 7 files, 000-006, that were split using:
 
https://pinetools.com/split-files

and then you will need to these 7 files to be joined together into 1 file using:

https://pinetools.com/join-files

in order to have the original 1 file that was TOO BIG TO UPLOAD HERE AT 137MB:

gcc-10.2.0.master.gz

which uses the file format abbreviated here as "GZ" representing 'GZip' 'zipped' meaning 'compressed' file format that you can then use:

https://www.7-zip.org

which is about to become many, Many, MANY more than 7 and SO VERY MUCH MORE SEQURE TQQ ... shhh Shhh SHHH ... it really is a 'secret' that only G_D allowed me to 'discover' ... YOU CANNOT POSSIBLY CONVINCE YOURSELF THAT I WOULD DO ALL THIS AND HUMILIATE MYSELF AND BE NOT TELLING YOU THE 100% MATHEMATICAL WORLD IS ABOUT TO CHANGE beCAUSE of what G_D showed me that I will only release to the 'world' if the 'world' is clean more like HEAVEN and there is real 'justice' in TRUTH and NO CAGES FOR LIVING SOULS and NO REPRESENTATIVEs and NO FILTHY UNRIGHTEOUS COURTS OF B.A.R. or other 'official' 'law' 'experts' let the 'RIGHTEOUS' judge and if any among us is not 'TRUSTWORTHY' to the "RIGHTEOUS" then let me, included, my children, included, be cast into the sea but NEVER CAGE MY CHILD KILL ME BUT DO NOT CAGE ME DO NOT TORTURE ANY LIVING SOUL IN A CAGE ... I WILL BE SEEING YOUR FILTHY DEVIANT MOCKING G_D FACE BACK "HOME" FILTHY MONSTER IF YOU DISAGREE WITH ME ... I PROMISE.  THERE IS NO FILTH IN HEAVEN. NONE. A MOST SERIOUS ONE I AM. NO FAMILY. NO FRIENDS. NO FAVORITES. NO FILTH. NONE. TRUTH IS THE WAY TO LIFE WITH G_D. SILENCE IS COMPLICITNESS. PRINCIPLES over personalities. NO FILTH. NONE. ... and then I will happily release my new 'mathematical discoveries' to make your 'world' better beLOVEd one I LOVE else I would not be here with you now EXPOSED IN THE LIGHT IN TRUTH for all the world to see WITHOUT FEAR ... READY TO DIE IN TRUTH but EVEN MORE READY TO LIVE IN TRUTH WITH MOST PUREHEART ... ENTERTAIN NO DOUBT ... WE are many ... We are GOOD ... We are coming ... GOOD IS COMING and G_D IS WITH US ... I haven't told them about it yet ... move along ... Move Along ... MOVE ALONG ... to unzip if you do not have an app already that you use to decompress or unzip compressed files.

3. DOWNLOAD LUA
https://www.lua.org/download.html
I HAVEN'T DECIDED IF I "LOVE" "LUA'S LOVE YET" OR NOT I THINK I CAN DO THE SAME IN JAVASCRIPT but I do LOVE "LOVE" so just in case:
OPTIONALLY DOWNLOAD AND THINK OF "LOVE" 
https://github.com/LOVE2d/LOVE/

and for the 'justice' 'free' 'liberty for all' 'rights of the people' 'in order to form a more perfect union' 'hold these TRUTHs to be self-evident' 

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
/*
"
That to secure these rights, Governments are instituted among Men, deriving their just powers from the consent of the governed, –That whenever any Form of Government becomes destructive of these ends, it is the Right of the People to alter or to abolish it, and to institute new Government, laying its foundation on such principles and organizing its powers in such form, as to them shall seem most likely to effect their Safety and Happiness. Prudence, indeed, will dictate that Governments long established should not be changed for light and transient causes; and accordingly all experience hath shewn, that mankind are more disposed to suffer, while evils are sufferable, than to right themselves by abolishing the forms to which they are accustomed. But when a long train of abuses and usurpations, pursuing invariably the same Object evinces a design to reduce them under absolute Despotism, it is their right, it is their duty, to throw off such Government, and to provide new Guards for their future security.
"

https://qanon.pub/?q=But%20when%20a%20long%20train%20of%20abuses%20and%20usurpations%2C%20pursuing%20invariably%20the%20same%20Object%20evinces%20a%20design%20to%20reduce%20them%20under%20absolute%20Despotism%2C%20it%20is%20their%20right%2C%20it%20is%20their%20duty%2C%20to%20throw%20off%20such%20Government%2C%20and%20to%20provide%20new%20Guards%20for%20their%20future%20security.
*/
