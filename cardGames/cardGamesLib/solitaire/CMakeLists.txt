cmake_minimum_required(VERSION 3.24)
project(solitaireLib)

set(CMAKE_CXX_STANDARD 17)

add_library(solitaireLib solitaire.cpp solitaire.h)
link_directories(solitaireLib ${CMAKE_CURRENT_LIST_DIR}/../../lib)
target_link_libraries(solitaireLib deckLib)
target_include_directories(solitaireLib PUBLIC ${CMAKE_CURRENT_LIST_DIR}/../../include)

add_custom_command(TARGET solitaireLib
        PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_LIST_DIR}/solitaire.h ${CMAKE_CURRENT_LIST_DIR}/../include/)

add_custom_command(TARGET solitaireLib
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy  $<TARGET_FILE:warLib> ${CMAKE_CURRENT_LIST_DIR}/../lib/)
