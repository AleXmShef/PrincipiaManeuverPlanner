cmake_minimum_required(VERSION 3.10)

project(PrincipiaManeuverPlanner LANGUAGES CXX CSharp)

SET(CMAKE_CXX_STANDARD 17 CACHE STRING "C++ Standard used for the build. C++17 is preferred")
SET_PROPERTY(CACHE CMAKE_CXX_STANDARD PROPERTY STRINGS 17 14 11)
SET(CMAKE_CXX_STANDARD_REQUIRED ON)
#enable_language(CSharp)

SET(KspDir "C:/Kerbal Space Program")

add_subdirectory(src/plugin)
add_subdirectory(src/cpp_cli_connector)
