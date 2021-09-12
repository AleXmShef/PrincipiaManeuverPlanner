SET(ProjectName PrincipiaManeuverPlanner)
add_library(${ProjectName} SHARED "main.cs")

target_link_libraries(${ProjectName} "cpp_cli_connector")

set_property(TARGET ${ProjectName} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.5")

SET(KspApiDir "${KspDir}/KSP_x64_Data/Managed")

LIST(APPEND vs_dn_references "Microsoft.CSharp")
LIST(APPEND vs_dn_references "PresentationCore")
LIST(APPEND vs_dn_references "PresentationFramework")
LIST(APPEND vs_dn_references "System")
LIST(APPEND vs_dn_references "System.Xaml")
LIST(APPEND vs_dn_references "System.Xml")
LIST(APPEND vs_dn_references "System.Xml.Linq")
LIST(APPEND vs_dn_references "WindowsBase")

set_target_properties(${ProjectName} PROPERTIES 
    VS_DOTNET_REFERENCE_UnityEngine "${KspApiDir}/UnityEngine.dll")

set_target_properties(${ProjectName} PROPERTIES 
    VS_DOTNET_REFERENCE_UnityEngine.CoreModule "${KspApiDir}/UnityEngine.CoreModule.dll")

set_target_properties(${ProjectName} PROPERTIES 
    VS_DOTNET_REFERENCE_Assembly-CSharp "${KspApiDir}/Assembly-CSharp.dll")



