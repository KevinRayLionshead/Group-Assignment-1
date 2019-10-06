#pragma once

#include "PluginSettings.h"
#include "DLLClass.h"
#ifdef __cplusplus
extern "C"
{
#endif
	PLUGIN_API void Save(float* objectList);
	PLUGIN_API float* Load();
#ifdef __cplusplus
}
#endif