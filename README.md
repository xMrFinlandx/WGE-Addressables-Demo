# Addressables Demo for WorldGraphEditor

A demo project showing how to integrate [WorldGraphEditor](https://assetstore.unity.com/packages/slug/306228) with Addressables and the Zenject DI container: a custom `ITransitionManager` implementation, additive scene loading through a two-layer scene-loading service, and responsibility split into small services around scene transitions.

Architecture overview: [documentation](https://intareu.com/resources/addressables)

## Requirements

- **WorldGraphEditor** 1.3+
- **Zenject**
- **Addressables**
- **Unity 6.0+**

> WorldGraphEditor is not included in this repository and requires a separate license.

## Getting Started

1. Clone or download this repository and open the folder in Unity Hub.
2. Install **WorldGraphEditor** from the Asset Store into the project.
3. Install **Zenject** (via Package Manager or Asset Store).
4. Install **Addressables** (via Package Manager).
5. Open the **Boot** scene (`Assets/AddressablesDemo/Scenes/Boot.unity`) and press Play — it loads the first gameplay scene automatically.
