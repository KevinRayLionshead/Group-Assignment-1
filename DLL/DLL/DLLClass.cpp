#include "DLLClass.h"

void DLLClass::Save(float* objectInfo)
{
	ofstream file("Objects.txt", ios::out);
	
	if (file.is_open())
	{
		float length = objectInfo[0];
		for(int i = 0; i < length+1; i++)
		{
			file << objectInfo[i]<< endl;
		}
	}
	file.close();
}

float* DLLClass::Load()
{
	ifstream file("Objects.txt", ios::in);
	float* tempFloat = new float[0];
	
	if (file.is_open())
	{
		string buffer;
		getline(file, buffer);
		float length = stof(buffer);
		tempFloat = new float[(size_t)length];
		tempFloat[0] = length;

		for (int i = 0; i < length; i++)
		{
			getline(file, buffer);
			tempFloat[i + 1] = stof(buffer);
		}
	}
	file.close();
	return tempFloat;

}
