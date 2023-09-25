cmake_minimum_required(VERSION 3.24)
project(deckLib)

set(CMAKE_CXX_STANDARD 17)

################################################################################
# Make the shared libraries
################################################################################
#Decklib library
add_library(deckLib SHARED deckLib.cpp)

################################################################################
# Make an Executable
################################################################################
message("-- Making executable for testing --")
add_executable(deckLib_test test/deckLib_test.cpp)
include_directories(${CMAKE_CURRENT_SOURCE_DIR}/lib)
target_link_libraries(deckLib_test deckLib)

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${PROJECT_SOURCE_DIR}/../libraries/deckLib/)

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${PROJECT_SOURCE_DIR}/lib/)

#add_custom_command(TARGET deckLib
#        POST_BUILD
#        COMMAND ${CMAKE_COMMAND} -E copy deckLib.h ${PROJECT_SOURCE_DIR}/../libraries/deckLib/)

