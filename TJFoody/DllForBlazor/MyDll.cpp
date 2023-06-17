#include"pch.h"
#include"MyDll.h"
#include <cstdlib>
#include<ctime>
#include<stdio.h>


extern "C" __declspec(dllexport) int MyAdd(int x, int y)
{
	return x + y ;
}
extern "C" __declspec(dllexport) int MyMinus(int x, int y)
{
	return x - y;
}
extern "C" __declspec(dllexport) int MyAvatar()
{
	//有个五个头像可供选择

	srand(time(0));
	int ptr = rand() % 5;
	return ptr;
}