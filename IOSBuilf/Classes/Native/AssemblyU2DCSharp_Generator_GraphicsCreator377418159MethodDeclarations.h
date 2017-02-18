#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// Generator.GraphicsCreator
struct GraphicsCreator_t377418159;
// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.Material
struct Material_t193706927;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_t686124026;

#include "codegen/il2cpp-codegen.h"
#include "UnityEngine_UnityEngine_Sprite309593783.h"
#include "UnityEngine_UnityEngine_Material193706927.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// System.Void Generator.GraphicsCreator::.ctor(UnityEngine.Sprite,UnityEngine.Sprite,UnityEngine.Material)
extern "C"  void GraphicsCreator__ctor_m2896370723 (GraphicsCreator_t377418159 * __this, Sprite_t309593783 * ___c0, Sprite_t309593783 * ___bg1, Material_t193706927 * ___line2, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject Generator.GraphicsCreator::DrawBackground(System.Int32,System.Int32)
extern "C"  GameObject_t1756533147 * GraphicsCreator_DrawBackground_m2156846318 (GraphicsCreator_t377418159 * __this, int32_t ___width0, int32_t ___height1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject[] Generator.GraphicsCreator::DrawCircles(UnityEngine.Vector2[])
extern "C"  GameObjectU5BU5D_t3057952154* GraphicsCreator_DrawCircles_m1964341953 (GraphicsCreator_t377418159 * __this, Vector2U5BU5D_t686124026* ___points0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject[] Generator.GraphicsCreator::DrawLines(UnityEngine.GameObject[])
extern "C"  GameObjectU5BU5D_t3057952154* GraphicsCreator_DrawLines_m776337781 (GraphicsCreator_t377418159 * __this, GameObjectU5BU5D_t3057952154* ___c0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Vector2 Generator.GraphicsCreator::GetLineCenter(UnityEngine.Vector3,UnityEngine.Vector3)
extern "C"  Vector2_t2243707579  GraphicsCreator_GetLineCenter_m2645538495 (GraphicsCreator_t377418159 * __this, Vector3_t2243707580  ___from0, Vector3_t2243707580  ___to1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
