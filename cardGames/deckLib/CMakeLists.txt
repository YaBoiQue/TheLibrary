cmake_minimum_required(VERSION 3.24)
project(deckLib)

set(CMAKE_CXX_STANDARD 17)

################################################################################
# Make the shared libraries
################################################################################
#Decklib library
add_library(deckLib SHARED deckLib.cpp deckLib.h)
target_include_directories(deckLib PUBLIC ${CMAKE_CURRENT_LIST_DIR})
include(GNUInstallDirs)
set_target_properties(deckLib PROPERTIES SOVERSION 1)
set_target_properties(deckLib PROPERTIES PUBLIC_HEADER deckLib.h)
install(TARGETS deckLib
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    PUBLIC_HEADER DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})

configure_file(deckLib.pc.in deckLib.pc @ONLY)
install(FILES ${CMAKE_BINARY_DIR}/deckLib.pc
        DESTINATION ${CMAKE_INSTALL_DATAROOTDIR}/pkgconfig)

################################################################################
# Make an Executable
################################################################################
message("-- Making executable for testing --")
add_executable(deckLib_test test/deckLib_test.cpp)
link_directories(${CMAKE_CURRENT_LIST_DIR}/lib)
target_link_libraries(deckLib_test deckLib)
target_include_directories(deckLib_test PUBLIC ${CMAKE_CURRENT_LIST_DIR}/include)
target_include_directories(deckLib_test PUBLIC ${CMAKE_CURRENT_LIST_DIR})

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${CMAKE_CURRENT_LIST_DIR}/../../libraries/)

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${CMAKE_CURRENT_LIST_DIR}/lib/)

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${CMAKE_CURRENT_LIST_DIR}/../lib/)

add_custom_command(TARGET deckLib
        PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_SOURCE_DIR}/deckLib.h ${CMAKE_CURRENT_LIST_DIR}/../../includes/)

add_custom_command(TARGET deckLib
        PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_SOURCE_DIR}/deckLib.h ${CMAKE_CURRENT_LIST_DIR}/include/)

add_custom_command(TARGET deckLib
        PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_SOURCE_DIR}/deckLib.h ${CMAKE_CURRENT_LIST_DIR}/../include/)

