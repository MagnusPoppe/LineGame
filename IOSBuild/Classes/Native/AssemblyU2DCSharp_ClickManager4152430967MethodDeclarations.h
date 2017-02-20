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

// ClickManager
struct ClickManager_t4152430967;
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.LineRenderer
struct LineRenderer_t849157671;
// System.String
struct String_t;

#include "codegen/il2cpp-codegen.h"
#include "UnityEngine_UnityEngine_GameObject1756533147.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_LineRenderer849157671.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "mscorlib_System_String2029220233.h"

// System.Void ClickManager::.ctor()
extern "C"  void ClickManager__ctor_m1978372082 (ClickManager_t4152430967 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void ClickManager::Start()
extern "C"  void ClickManager_Start_m2385335734 (ClickManager_t4152430967 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void ClickManager::Update()
extern "C"  void ClickManager_Update_m2203926979 (ClickManager_t4152430967 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject[] ClickManager::FindChildrenLines(UnityEngine.GameObject)
extern "C"  GameObjectU5BU5D_t3057952154* ClickManager_FindChildrenLines_m1972386220 (ClickManager_t4152430967 * __this, GameObject_t1756533147 * ___g0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void ClickManager::testForIntersect()
extern "C"  void ClickManager_testForIntersect_m3944877772 (ClickManager_t4152430967 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean ClickManager::IntersectionBetweenToPkt(UnityEngine.Vector2,UnityEngine.Vector2,UnityEngine.Vector2)
extern "C"  bool ClickManager_IntersectionBetweenToPkt_m3490958669 (ClickManager_t4152430967 * __this, Vector2_t2243707579  ___isect0, Vector2_t2243707579  ___pk11, Vector2_t2243707579  ___pk22, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void ClickManager::ColorLine(UnityEngine.LineRenderer,UnityEngine.Color)
extern "C"  void ClickManager_ColorLine_m1448105539 (ClickManager_t4152430967 * __this, LineRenderer_t849157671 * ___line0, Color_t2020392075  ___color1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void ClickManager::correctLinePositions(UnityEngine.Vector3,UnityEngine.Vector3)
extern "C"  void ClickManager_correctLinePositions_m4108975698 (ClickManager_t4152430967 * __this, Vector3_t2243707580  ___current0, Vector3_t2243707580  ___corrected1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject ClickManager::GetOtherLine(System.String)
extern "C"  GameObject_t1756533147 * ClickManager_GetOtherLine_m3951406931 (ClickManager_t4152430967 * __this, String_t* ___GameObjectName0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Vector2 ClickManager::GetMouseWorld2DPosition()
extern "C"  Vector2_t2243707579  ClickManager_GetMouseWorld2DPosition_m3717698051 (ClickManager_t4152430967 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject ClickManager::IdentifyClickedItem()
extern "C"  GameObject_t1756533147 * ClickManager_IdentifyClickedItem_m672264059 (ClickManager_t4152430967 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean ClickManager::clicked(UnityEngine.Vector2,UnityEngine.Vector2)
extern "C"  bool ClickManager_clicked_m3409681521 (ClickManager_t4152430967 * __this, Vector2_t2243707579  ___go0, Vector2_t2243707579  ___mouse1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
