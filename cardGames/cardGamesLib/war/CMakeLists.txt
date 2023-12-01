cmake_minimum_required(VERSION 3.24)
project(warLib)

set(CMAKE_CXX_STANDARD 17)

add_library(warLib war.cpp war.h)
link_directories(warLib ${CMAKE_CURRENT_LIST_DIR}/../../lib)
target_link_libraries(warLib deckLib)
target_include_directories(warLib PUBLIC ${CMAKE_CURRENT_LIST_DIR}/../../include)

add_custom_command(TARGET warLib
        PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_LIST_DIR}/war.h ${CMAKE_CURRENT_LIST_DIR}/../include/)

add_custom_command(TARGET warLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy  $<TARGET_FILE:warLib> ${CMAKE_CURRENT_LIST_DIR}/../lib/)
