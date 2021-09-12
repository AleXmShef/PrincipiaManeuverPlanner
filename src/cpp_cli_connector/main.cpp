#include "APIFunctions.hpp"
#define M_EXPORT __declspec(dllexport)

class M_EXPORT MyClass {
public:
	MyClass(int a) { b = a; };

	int b;
};