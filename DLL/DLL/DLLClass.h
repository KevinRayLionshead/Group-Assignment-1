#pragma once

#include "PluginSettings.h"
#include <iostream>
#include <fstream>
#include <vector>
#include<string>
using namespace std;
using std::vector;

class PLUGIN_API DLLClass
{
public:
	void Save(float* objectInfo);

	float* Load();
};