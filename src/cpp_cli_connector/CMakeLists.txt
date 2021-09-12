SET(ProjectName cpp_cli_connector)
add_library(${ProjectName} SHARED "main.cpp")
target_compile_options(${ProjectName} PRIVATE /clr)
target_compile_options(${ProjectName} PRIVATE /fp:precise)

set_property(TARGET ${ProjectName} PROPERTY VS_GLOBAL_ROOTNAMESPACE cpp_cli_connector)

set_property(TARGET ${ProjectName} PROPERTY VS_GLOBAL_KEYWORD "ManagedCProj")

set_property(TARGET ${ProjectName} PROPERTY VS_GLOBAL_CLRSupport "true")

set_property(TARGET ${ProjectName} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.0")

set_property(TARGET ${ProjectName} PROPERTY VS_DOTNET_REFERENCES "System" "System.Data" "System.Drawing" "System.Windows.Forms" "System.Xml")

# Note: Modification of compiler flags is required for CLR compatibility now that we are using .resx files.
string(REPLACE "/EHsc" "" CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS}")
string(REPLACE "/RTC1" "" CMAKE_CXX_FLAGS_DEBUG "${CMAKE_CXX_FLAGS_DEBUG}")

SET(Path_To_GMAT "${CMAKE_SOURCE_DIR}/dependencies/gmat-git")
IF(EXISTS ${Path_To_GMAT})
	target_link_libraries(${ProjectName} "${Path_To_GMAT}/application/bin/GmatBase.lib")
	target_link_libraries(${ProjectName} "${Path_To_GMAT}/application/bin/GmatUtil.lib")
ELSE()
	message(ERROR "GMAT not found!")
ENDIF()

# Add GMAT base include directories
FILE(GLOB_RECURSE gmat_headers RELATIVE ${CMAKE_CURRENT_SOURCE_DIR} "${CMAKE_SOURCE_DIR}/dependencies/gmat-git/src/base/*.hpp")
FOREACH(file_path ${gmat_headers})
	GET_FILENAME_COMPONENT(dir_path ${file_path} PATH)
	SET(dir_list ${dir_list} ${dir_path})
ENDFOREACH()

# Add GMAT util include directories
FILE(GLOB_RECURSE gmat_headers RELATIVE ${CMAKE_CURRENT_SOURCE_DIR} "${CMAKE_SOURCE_DIR}/dependencies/gmat-git/src/gmatutil/*.hpp")
FOREACH(file_path ${gmat_headers})
	GET_FILENAME_COMPONENT(dir_path ${file_path} PATH)
	SET(dir_list2 ${dir_list2} ${dir_path})
ENDFOREACH()

target_include_directories(${ProjectName} PRIVATE ${dir_list})
target_include_directories(${ProjectName} PRIVATE ${dir_list2})