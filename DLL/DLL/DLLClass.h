#pragma once

#include "PluginSettings.h"
#include <iostream>
#include <fstream>
using namespace std;

class PLUGIN_API DLLClass
{
public:
	void Save();

	void Load();
};