import '../common/cards/content_card.dart';
import 'package:flutter/material.dart';
import 'package:go_router/src/misc/errors.dart';

class NotFoundScreen extends StatefulWidget {
  const NotFoundScreen({super.key, required this.goRouterException});

  final GoException? goRouterException;

  @override
  State<NotFoundScreen> createState() => _NotFoundScreenState();
}

class _NotFoundScreenState extends State<NotFoundScreen> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ContentCard(
        child: Column(
          children: [
            const Text("404", style: TextStyle(fontSize: 50)),
            const Text(
              "This page cannot be found, please try again later",
              style: TextStyle(fontSize: 25),
            ),
            Text("GoRouter Exception: ${widget.goRouterException}"),
          ],
        ),
      ),
    );
  }
}
