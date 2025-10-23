import 'package:flutter/material.dart';

import '../../../../styles/colours.dart';

class StackedContentCard extends StatefulWidget {
  final Widget child;

  const StackedContentCard({super.key, required this.child});

  @override
  State<StackedContentCard> createState() => _StackedContentCardState();
}

class _StackedContentCardState extends State<StackedContentCard> {
  @override
  Widget build(BuildContext context) {
    return Stack(children: [parentCard(context), childCard()]);
  }

  Widget parentCard(BuildContext context) {
    return Positioned.fill(child: Card(elevation: 3.0, color: cardColour));
  }

  Widget childCard() {
    return Positioned(
      left: 10,
      right: 10,
      top: 10,
      bottom: 10,
      child: Column(children: [Flexible(child: widget.child)]),
    );
  }

  GlobalKey _getGlobalKey() {
    return GlobalKey();
  }
}
