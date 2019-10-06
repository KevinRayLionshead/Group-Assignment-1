#include "Wrapper.h"

DLLClass dLLClass;

PLUGIN_API void Save(float* objectList)
{
	return dLLClass.Save(objectList);
}

PLUGIN_API float* Load()
{
	return dLLClass.Load();
}
