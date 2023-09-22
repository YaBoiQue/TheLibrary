cmake_minimum_required(VERSION 3.24)
project(deckLib)

set(CMAKE_CXX_STANDARD 17)

add_library(deckLib SHARED deckLib.cpp
        deckLib.h)
add_executable(deckLib_test test/deckLib_test.cpp)

find_library(DECKLIB_TEST deckLib lib)
target_link_libraries(deckLib_test PUBLIC ${DECKLIB_TEST})

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${PROJECT_SOURCE_DIR}/../libraries/deckLib/)

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:deckLib> ${PROJECT_SOURCE_DIR}/lib/)

add_custom_command(TARGET deckLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${PROJECT_SOURCE_DIR}/deckLib.h ${PROJECT_SOURCE_DIR}/../libraries/deckLib/)

