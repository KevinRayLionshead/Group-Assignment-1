#pragma once

#ifdef DLL_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif DLL_IMPORTS 
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif