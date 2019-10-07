#include "DLLClass.h"

void DLLClass::Save(float* objectInfo)
{
	//opens the file and deletes its contents
	ofstream file("Objects.txt", ios::out, ios::trunc);
	
	if (file.is_open())
	{
		//writes every float to file
		float length = objectInfo[0];
		for(int i = 0; i < length; i++)
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
		//reads in the first float
		//this float represents the number of floats in the file
		getline(file, buffer);
		float length = stof(buffer);
		//creates an array large enough to hold every float, including the size
		tempFloat = new float[(int)length];
		//sets the size as the first variable in the array
		tempFloat[0] = length;

		//reads in all the floats
		for (int i = 1; i < (int)length; i++)
		{
			getline(file, buffer);
			tempFloat[i] = stof(buffer);
		}
		/*while (!file.eof())
		{
			getline(file, buffer);
			tempFloat[i + 1] = stof(buffer);
			i++;
		}*/
	}
	file.close();
	//sends the array to unity
	return tempFloat;

}
